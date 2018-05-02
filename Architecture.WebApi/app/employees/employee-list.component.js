(function() {
    "use strict";

    var module = angular.module("employee");

    function controller(employeeService) {

        var model = this;
        model.employees = [];
        model.employee = {};
        function getEmployees() {
            employeeService.getAll().then(function (employees) {
                model.employees = employees;
            });
        }
        model.$onInit = function() {
            getEmployees();
        };
        model.addEmployee = function (form, employee) {
            if (form.$invalid) {
                return;
            }
            employeeService
                .create({
                    name: employee.name,
                    email: employee.email,
                    address: employee.address,
                    managerId: employee.manager && employee.manager.id
                }).then(function() {
                    getEmployees();
                    model.employee = {};
                });
        }
    }

    module.component("employeeList", {
        templateUrl: "/app/employees/employee-list.component.html",
        controllerAs: "model",
        controller: ["employeeService", controller]
    });

} ());