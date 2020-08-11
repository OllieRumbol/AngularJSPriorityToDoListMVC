//Create module 
var PriorityList = angular.module('PriorityList', []);

//Create service
PriorityList.service("GetTasksFromCSV", function ($http, $q) {
    return {
        //Get tasks, provide the level of task you want 
        //1: High Priority
        //2: Medium Priority
        //3: Low Priority
        //4: Completed
        GetTasks: function (number) {
            var deferred = $q.defer();
            $http({
                url: "GetTasks",
                method: "GET",
                params: { level: number }
            })
                //Returns Json result 
                .then(function (response) {
                    //if it works sets data
                    deferred.resolve(response.data);
                }).catch(function (response) {
                    //Catch execeptions
                    deferred.reject(response);
                });
            return deferred.promise;
        },

        //Add a task, provide task and level
        AddTask: function (task, number) {
            var deferred = $q.defer();
            //HTTP get call
            $http({
                url: "AddTask",
                method: "GET",
                params: { task: task, level: number }
            })
                //Returns Json result 
                .then(function (response) {
                    //if it works sets data
                    deferred.resolve(response.data);
                }).catch(function (response) {
                    //Catch execeptions
                    deferred.reject(response);
                });
            return deferred.promise;
        },

        //Clear all tasks in that level
        ClearTasks: function (number) {
            var deferred = $q.defer();
            //HTTP get call 
            $http({
                url: "ClearTasks",
                method: "GET",
                params: { level: number }
            })
                //Returns Json result 
                .then(function (response) {
                    //if it works sets data
                    deferred.resolve(response.data);
                }).catch(function (response) {
                    //Catch execeptions
                    deferred.reject(response);
                });
            return deferred.promise;
        },

        //Remove a particular task in that level
        RemoveTask: function (task, number) {
            var deferred = $q.defer();
            //HTTP get call
            $http({
                url: "RemoveTask",
                method: "GET",
                params: { task: task, level: number }
            })
                //Returns Json result 
                .then(function (response) {
                    //if it works sets data
                    deferred.resolve(response.data);
                }).catch(function (response) {
                    //Catch execeptions
                    deferred.reject(response);
                });
            return deferred.promise;
        }
    }
});

//Create controller
PriorityList.controller("Main", function ($scope, GetTasksFromCSV) {
    //Text input 
    $scope.text = "";

    //Arrys
    $scope.HighPriority = [];
    $scope.MediumPriority = [];
    $scope.LowPriority = [];
    $scope.CompletedTasks = [];

    //Buttons
    //Adding the text to the tables 
    //Add to High
    $scope.addHighTask = function () {
        if (validate($scope.text) && duplicateInArray($scope.HighPriority, $scope.text)) {
            addHelper(1);
        }
    }

    //Add to Medium
    $scope.addMedTask = function () {
        if (validate($scope.text) && duplicateInArray($scope.MediumPriority, $scope.text)) {
            addHelper(2);
        }
    }

    //add to Low
    $scope.addLowTask = function () {
        if (validate($scope.text) && duplicateInArray($scope.LowPriority, $scope.text)) {
            addHelper(3);
        }
    }

    //Helper function for adding to text to a priority table
    function addHelper(priorityLevel) {
        //Using service 
        GetTasksFromCSV.AddTask($scope.text, priorityLevel).then(function success(data) {
            //If everything goes to plan set the array as the successful data
            if (priorityLevel === 1) {
                setHighPriorityTasks(data);
            }
            else if (priorityLevel === 2) {
                setMediumPriorityTasks(data);
            }
            else if (priorityLevel === 3) {
                setLowPriorityTasks(data);
            }
            else {
                Console.log("Task not added to level " + priorityLevel);
            }
            clearText();
        }).catch(function (responce) {
            errorLog(responce);
        });
    }

    //Button click for clear text
    $scope.clear = function () {
        clearText();
    }

    //Validate the test input 
    //Can't be empty
    function validate(text) {
        if (text.length === 0) {
            alert("No text in input field. Please add text before adding the task.");
            return false;
        }
        else {
            return true;
        }
    };

    //Check to see if an arry already contains a value
    function duplicateInArray(array, value) {
        for (var i = 0; i < array.length; i++) {
            if (array[i].Name === value) {
                alert("That priority list already contains that task.");
                return false;
            }
        }
        return true;
    };

    //Clear text input
    function clearText() {
        $scope.text = "";
    }

    //Adding to the completed table from either High, Medium or Low priority table 
    $scope.doneHigh = function (task) {
        $scope.removeHigh(task);
        var value = task + ',High Priority';
        addToDone(value);
    }

    //Adding to medium
    $scope.doneMed = function (task) {
        $scope.removeMed(task);
        var value = task + ',Medium Priority';
        addToDone(value);
    }

    //Adding to low
    $scope.doneLow = function (task) {
        $scope.removeLow(task);
        var value = task + ',Low Priority';
        addToDone(value);
    }

    //Helper function for adding to the completed table 
    function addToDone(value) {
        GetTasksFromCSV.AddTask(value, 4).then(function success(data) {
            //If everything goes to plan set the array as the successful data
            setCompletedTasks(data);
            $scope.text = "";
        }).catch(function (responce) {
            errorLog(responce);
        });
    }

    //Removing from High, Medium or Low priority table
    $scope.removeHigh = function (task) {
        removeHelper(task, 1);
    }

    $scope.removeMed = function (task) {
        removeHelper(task, 2);
    }

    $scope.removeLow = function (task) {
        removeHelper(task, 3);
    }

    //Helper function for removing from list 
    function removeHelper(task, level) {
        //Using the service 
        GetTasksFromCSV.RemoveTask(task, level).then(function success(data) {
            //If everything goes to plan set the array as the successful data
            if (level === 1) {
                setHighPriorityTasks(data);
            }
            else if (level === 2) {
                setMediumPriorityTasks(data);
            }
            else if (level === 3) {
                setLowPriorityTasks(data);
            }
            else {
                Console.log("Cant remove task from level " + level);
            }
        }).catch(function (responce) {
            errorLog(responce);
        });
    }

    //Resets all tables 
    $scope.reset = function () {
        //Using a for loops to reset all lists 
        for (var i = 1; i < 5; i++) {
            resetHelper(i);
        }
    }

    //Helper function for reseting 
    function resetHelper(level) {
        //Using the service 
        GetTasksFromCSV.ClearTasks(level).then(function success(data) {
            //If everything goes to plan set the array as the successful data
            if (level === 1) {
                setHighPriorityTasks(data);
            }
            else if (level === 2) {
                setMediumPriorityTasks(data);
            }
            else if (level === 3) {
                setLowPriorityTasks(data);
            }
            else if (level === 4) {
                setCompletedTasks(data);
            }
            else {
                Console.log("Cannot reset level " + level);
            }
        }).catch(function (responce) {
            errorLog(responce);
        });
    }

    //On load 
    $scope.getTasks = function () {
        //Using a for loops to load all lists 
        for (var i = 1; i < 5; i++) {
            loadHelper(i);
        }
    }

    //Helper function for loading lists
    function loadHelper(level) {
        //Using the service 
        GetTasksFromCSV.GetTasks(level).then(function success(data) {
            //If everything goes to plan set the array as the successful data
            if (level === 1) {
                setHighPriorityTasks(data);
            }
            else if (level === 2) {
                setMediumPriorityTasks(data);
            }
            else if (level === 3) {
                setLowPriorityTasks(data);
            }
            else if (level === 4) {
                setCompletedTasks(data);
            }
            else {
                Console.log("Can't load level " + level);
            }
        }).catch(function (responce) {
            errorLog(responce);
        });
    }

    //Set High priority Tasks
    function setHighPriorityTasks(data) {
        $scope.HighPriority = data;
    }

    //Set Medium priority Tasks
    function setMediumPriorityTasks(data) {
        $scope.MediumPriority = data;
    }

    //Set low priority Tasks
    function setLowPriorityTasks(data) {
        $scope.LowPriority = data;
    }

    //Set completed tasks
    function setCompletedTasks(data) {
        $scope.CompletedTasks = data;
    }

    //Error logs 
    function errorLog(responce) {
        //Catch errors and log them
        console.log(responce);
    }
});