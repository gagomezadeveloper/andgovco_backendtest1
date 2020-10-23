"use strict";
var app = angular.module("App", ["ngRoute"]);
var dominio =
    (() => {
        app.controller('MainController', function ($scope, $timeout, $http) {

            //#region Variables
            $scope.mode = 'index';
            $scope.dominio = `${document.location.protocol}/${document.location.host}/`;
            $scope.loadingData = true;
            $scope.product = {};
            $scope.selectedElements = [];
            //#endregion

            //#region Tool bar
            $scope.CreateProduct = function () {
                $scope.mode = "create";
                $scope.formTitle = "Crear";
                $scope.product = {};
                $scope.product.productTypeID = 0;
                $scope.product.productStateID = 0;
                $scope.product.areaID = 0;
                $scope.product.purchaseDate = new Date();
                $scope.product.purchaseValue = 0;
            };

            $scope.EditProduct = function () {
                $scope.mode = "edit";
                $scope.formTitle = "Modificar";

                if ($scope.selectedElements.length != 0) {
                    $scope.product = $scope.selectedElements[0];
                    $scope.product.purchaseDate = new Date($scope.product.purchaseDate);
                } else {
                    $scope.product = {};
                }
            };

            $scope.DetailProduct = function () {
                $scope.mode = "detail";
                $scope.formTitle = "Detalle";

                if ($scope.selectedElements.length != 0) {
                    $scope.product = $scope.selectedElements[0];
                    $scope.product.purchaseDate = new Date($scope.product.purchaseDate);
                } 
            };

            $scope.ConfirmDeleteProduct = function () {
                $scope.mode = "delete";
                $scope.formTitle = "Eliminar";

                if ($scope.selectedElements.length == 1) {
                    $scope.product = $scope.selectedElements[0];
                }
            };

            $scope.Back = function () {                
                $scope.mode = 'index'; 
                $scope.GetProducts();
            };
            //#endregion

            //#region GetOpciones
            $scope.options = {};
            $scope.GetOptions = function () {

                if ($scope.loadingData) {
                    return;
                }

                $scope.loadingData = true;
                return new Promise(function (resolve, reject) {

                    try {

                        $http({

                            url: `api/products/getoptions`,
                            method: 'GET',
                            data: {},
                            config: {}

                        })
                            .then(function (response) {

                                angular.copy(response.data, $scope.options);

                                $scope.loadingData = false;
                                resolve();
                            })
                            .catch(function (error) {
                                console.log(error);
                                $scope.loadingData = false;
                                reject();
                            })

                    } catch (error) {
                        console.log(error);
                        $scope.loadingData = false;
                        reject();
                    }

                });

            };
            //#endregion

            //#region GetProductos
            $scope.products = [];
            $scope.GetProducts = function () {

                if ($scope.loadingData) {
                    return;
                }

                $scope.loadingData = true;
                $scope.selectedElements = [];
                $scope.allElementsSelected = false;
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
                            .catch(function (error) {
                                console.log(error);
                                $scope.loadingData = false;
                                reject();
                            })

                    } catch (error) {
                        console.log(error);
                        $scope.loadingData = false;
                        reject();
                    }

                });

            };
            //#endregion

            //#region SetProducto              
            $scope.SetProduct = function () {
                
                if($scope.mode == 'create') {
                    $scope.PostProducto();
                }

                if($scope.mode == 'edit') {
                    $scope.PutProducto();
                }

            };

            $scope.PostProducto = function () {
                if ($scope.loadingData) {
                    return;
                }

                $scope.loadingData = true;
                $scope.errors = {};
                return new Promise(function (resolve, reject) {

                    try {

                        $http({

                            url: `api/products`,
                            method: 'POST',
                            data: $scope.product,
                            config: {}

                        })
                            .then(function (response) {

                                console.log("response", response);

                                $scope.loadingData = false;
                                
                                $scope.Back();

                                resolve();
                            })
                            .catch(function (error) {
                                console.log("error", error);

                                angular.copy(error.data.errors, $scope.errors);

                                $scope.loadingData = false;
                                reject();
                            })

                    } catch (error) {
                        console.log(error);
                        $scope.loadingData = false;
                        reject();
                    }

                });
            };

            $scope.PutProducto = function () {
                if ($scope.loadingData) {
                    return;
                }

                $scope.loadingData = true;
                $scope.errors = {};
                return new Promise(function (resolve, reject) {

                    try {

                        $http({

                            url: `api/products/${$scope.product.id}`,
                            method: 'PUT',
                            data: $scope.product,
                            config: {}

                        })
                            .then(function (response) {

                                console.log("response", response);

                                $scope.loadingData = false;

                                $scope.Back();

                                resolve();
                            })
                            .catch(function (error) {
                                console.log("error", error);

                                angular.copy(error.data.errors, $scope.errors);

                                $scope.loadingData = false;
                                reject();
                            })

                    } catch (error) {
                        console.log(error);
                        $scope.loadingData = false;
                        reject();
                    }

                });
            };
            //#endregion

            //#region Select products            
            $scope.allElementsSelected = false;
            $scope.selectedElements = [];
            $scope.SelectAllElements = function () {
                try {

                    $scope.allElementsSelected = !$scope.allElementsSelected;

                    $scope.selectedElements = [];
                    $scope.products.map(it => {

                        it.selected = $scope.allElementsSelected;

                        if (it.selected) {
                            $scope.selectedElements.push(it);
                        }

                        return it;
                    });

                    console.log("elements", $scope.selectedElements);

                } catch (error) {
                    console.log(error);
                }
            };

            $scope.SelectElement = function (element) {
                try {

                    if (element.selected) {
                        $scope.selectedElements.push(element);
                    } else {
                        $scope.selectedElements = $scope.selectedElements.filter(e => e.$$hashKey !== element.$$hashKey);
                    }

                } catch (error) {
                    console.log(error);
                }
            };
            //#endregion

            //#region DeleteProducto            
            $scope.DeleteProduct = function () {

                if ($scope.loadingData) {
                    return;
                }

                $scope.loadingData = true;
                return new Promise(function (resolve, reject) {

                    try {

                        $http({

                            url: `api/products/${$scope.product.id}`,
                            method: 'DELETE',
                            data: {},
                            config: {}

                        })
                            .then(function (response) {


                                $scope.loadingData = false;

                                $scope.Back();

                                resolve();
                            })
                            .catch(function (error) {
                                console.log(error);
                                $scope.loadingData = false;
                                reject();
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

                await $scope.GetOptions();

                await $scope.GetProducts();

                //Testing -> Se valida para mantener la consola limpia en producción
                if ($scope.dominio.indexOf("localhost") != -1) {
                    console.log("producto", $scope.products[0]);
                }

            }();
            //#endregion

        });
    })();