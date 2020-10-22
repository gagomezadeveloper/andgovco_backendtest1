var app = angular.module("App", ["ngRoute"]);
var dominio =
    (() => {
        app.controller('MainController', function ($scope, $timeout, $http) {

            $scope.mode = "index";
            $scope.dominio = `${document.location.protocol}/${document.location.host}/`;
            $scope.loadingData = true;

            //#region GetProductos
            $scope.products = [];
            $scope.GetProducts = function () {

                if ($scope.loadingData) {
                    return;
                }

                $scope.loadingData = true;
                return new Promise(function (resolve, reject) {

                    try {

                        $http({

                            url: `api/products`,
                            method: 'GET',
                            data: {},
                            config: {}

                        })
                            .then(function (response) {

                                angular.copy(response.data, $scope.products);                                

                                $scope.loadingData = false;
                                resolve();
                            })
                            .catch(function (err) {
                                throw err;
                            })

                    } catch (error) {
                        console.log(error);
                        $scope.loadingData = false;
                        reject();
                    }

                });

            };
            //#endregion

            //#region Init
            $scope.init = async function () {

                await $timeout(function () {
                    $scope.loadingData = false;
                }, 500);

                await $scope.GetProducts();

                console.log("productos", $scope.products);

            }();
            //#endregion


        });
    })();