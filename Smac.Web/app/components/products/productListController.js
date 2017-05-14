(function (app) {
    app.controller('productListController', productListController);

    productListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function productListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.products = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProducts = getProducts;
        $scope.productName = '';
        $scope.parentID = '';

        $scope.searchMulti = searchMulti;

        $scope.deleteProduct = deleteProduct;
        $scope.overlay = true;
        $scope.selectAll = selectAll;
        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("products", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
                console.log(checked);
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        $scope.deleteMultipe = deleteMultipe;

        function deleteMultipe() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedProducts: JSON.stringify(listId)
                }
            }
            apiService.del('api/product/deletemulti', config, function (result) {
                notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi.');
                getProducts();
            }, function (error) {
                notificationService.displayError('Xóa không thành công');
            });
        }

        function deleteProduct(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/product/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function searchMulti() {
            console.log($scope.s);
            $scope.getDatatByS = function () {
                notificationService.displayError("Chức năng tìm kiếm nâng cao đang được xử lí");
            };
            $scope.getDatatByS();
        }

        $scope.Apply = Apply;

        function Apply() {
            switch ($scope.actions) {
                case 'delete':
                    $scope.deleteMultipe();
                    break;
                case 'publish':
                    alert("Public");
                    break;
                case 'unpublished':
                    alert("unpublished");
                    break;
                default:
                    alert("Bạn chưa chọn tác vụ nào");
            }
        }

        function loadParentCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadParentCategory();

        $scope.s = {};

        $scope.reset = function () {
            $scope.s = {};
        }

        function getProducts(page) {
            page = page || 0;
            var config = {
                params: {
                    //parentID: $scope.parentID,
                    productName: $scope.productName,
                    //productCategory: $scope.productCategory,
                    //fromPrice: $scope.fromPrice,
                    //toPrice: $scope.toPrice,
                    //fromQuantity: $scope.fromQuantity,
                    //toQuantity: $scope.toQuantity,
                    //status: $scope.status,
                    page: page,
                    pageSize: $scope.limitedRow
                }
            }
            apiService.get('/api/product/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                console.log(result.data);
                $scope.overlay = false;
                $scope.products = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load product failed.');
            });
        }

        $scope.getProducts();
    }
})(angular.module('smacshop.products'));