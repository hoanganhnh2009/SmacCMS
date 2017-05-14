/// <reference path="Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('smacshop.product_categories', ['smacshop.common']).config(config);

    config.$inject = ["$stateProvider", "$urlRouterProvider"]

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('products_categories', {
                url: "/products_categories",
                templateUrl: "/app/components/product_categories/productCategoryListView.html",
                controller: "productCategoryListController"
            })
            .state('productcategories_add', {
                url: "/productcategories_add",
                templateUrl: "/app/components/product_categories/productCategoryAddView.html",
                controller: "productCategoryAddController"
            })
            .state('productcategories_edit', {
                url: "/productcategories_edit/:id",
                templateUrl: "/app/components/product_categories/productCategoryEditView.html",
                controller: "productCategoryEditController"
            })
    }
})();