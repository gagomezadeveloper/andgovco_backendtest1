(() => {

    app.config(function ($routeProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "/Views/Inicio.html"
            })
            .when("/apiswagger", {
                templateUrl: "/Views/APISwagger.html"
            })
            .when("/coleccionpostman", {
                templateUrl: "/Views/ColeccionPostman.html"
            })
            .when("/diagramaer", {
                templateUrl: "/Views/DiagramaER.html"
            })
            .when("/diagramasecuencia", {
                templateUrl: "/Views/DiagramaSecuencia.html"
            })
            .when("/manualdespliegue", {
                templateUrl: "/Views/ManualDespliegue.html"
            })
            .when("/productos", {
                templateUrl: "/Views/Productos.html"
            })
            .when("/repositorio", {
                templateUrl: "/Views/Repositorio.html"
            })
            .otherwise({
                redirectTo: '/'
            });
    });
    
})();