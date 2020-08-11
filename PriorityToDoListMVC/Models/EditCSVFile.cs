using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PriorityToDoListMVC.Models
{
    public class EditCSVFile
    {
        public List<TasksModel> convert(string path)
        {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentException("Path can't be null or empty", "path");

            var query =
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 0)
                    .Select(l =>
                    {
                        var columns = l.Split(',');
                        return new TasksModel
                        {
                            Name = columns[0]
                        };
                    });
            return query.ToList();
        }

        public List<CompletedModel> convertToCompletedMdoel(string path)
        {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentException("Path can't be null or empty", "path");

            var query =
                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 0)
                    .Select(l =>
                    {
                        var columns = l.Split(',');
                        return new CompletedModel
                        {
                            Name = columns[0],
                            Priority = columns[1]                            
                        };
                    });
            return query.ToList();
        }

        private void pathCheck(string path)
        {
            if (String.IsNullOrWhiteSpace(path)) throw new ArgumentException("Path can't be null or empty", "path");
        }

        private void taskCheck(string task)
        {
            if (String.IsNullOrWhiteSpace(task)) throw new ArgumentException("Task can't be null or empty", "task");
        }

        public void add(string path, string task)
        {
            pathCheck(path);
            taskCheck(task);           

            StringBuilder CSVFile = new StringBuilder();
            CSVFile.AppendLine($"{task}");
            File.AppendAllText(path, CSVFile.ToString());
        }

        public void clear(string path)
        {
            pathCheck(path);

            File.WriteAllText(path, string.Empty);

            StringBuilder CSVFile = new StringBuilder();
            CSVFile.AppendLine("Name Of Task");
            File.AppendAllText(path, CSVFile.ToString());
        }

        public void remove(string path, string task)
        {
            pathCheck(path);
            taskCheck(task);

            var csvFile = File.ReadAllLines(path);

            clear(path);
            
            for (int i = 0; i < csvFile.Length; i++)
            {
                if (csvFile[i] != task && i !=0)
                {
                    add(path, csvFile[i]);
                }
            }
        }
    }
}