(function() {
    var module = angular.module("employee", ["ngComponentRouter"]);
    module.value("$routerRootComponent", "employeeApp");
    module.config(['$locationProvider', function ($locationProvider) {
        $locationProvider.hashPrefix('');
    }]);
}());