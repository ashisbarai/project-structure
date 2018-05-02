(function() {

    "use strict";

    var module = angular.module("employee");

    module.component("employeeApp", {
        templateUrl: "/app/core/employee-app.component.html",
        $routeConfig: [
            { path: "/list", component: "employeeList", name: "List" },
            { path: "/about", component: "employeeAbout", name: "About" },
            { path: "/**", redirectTo: ["List", ""] }
        ]
    });
    //module.component("employeeList", {
    //    template: "Hello"
    //});

    module.component("employeeAbout", {
        template: "About"
    });

}());