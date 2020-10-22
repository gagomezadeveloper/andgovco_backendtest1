var app = angular.module("App", ["ngRoute"]);

(() => {
    app.controller('MainController', function ($scope) {
        
        $scope.mode = "index";

    });
})();