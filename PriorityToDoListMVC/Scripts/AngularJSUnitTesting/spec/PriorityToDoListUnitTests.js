describe('Testing module', function () {

    beforeEach(module('PriorityList'));

    describe('Testing controller', function () {
        var scope, ctrl;

        beforeEach(inject(function ($controller, $rootScope) {
            scope = $rootScope.$new();
            ctrl = $controller('Main', { $scope: scope });
        }));

         
        it('Validate text', function () {
            expect(ctrl.validate("")).toBe(false);
        });

    });
});
