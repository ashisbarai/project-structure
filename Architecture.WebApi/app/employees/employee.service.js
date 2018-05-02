(function() {

    function employeeService($http) {
        var url = '/api/employee';
        function create(employee) {
            return $http.post(url, employee)
                .then(function(response) {
                    return response.data;
                });
        }

        function getAll() {
            return $http.get(url)
                .then(function (response) {
                    return response.data;
                });
        }

        return {
            create: create,
            getAll: getAll
        };
    }

    var module = angular.module("employee");
    module.factory("employeeService", ['$http', employeeService]);

}());