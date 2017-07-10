var AngularApp = angular.module("AngularApp", ['ui.bootstrap', 'pascalprecht.translate']);
//фильтрация даты
AngularApp.filter("jsDate", function () {
    return function (x) {
        return new Date(parseInt(x.substr(6)));
    };
});

//локализация
AngularApp.config(["$translateProvider", function ($translateProvider) {

    var ru_translations = {
        "language": "Язык",
        "col1": "Страна",
        "col2": "Город",
        "col3": "Улица",
        "col4": "Дом",
        "col5": "Индекс",
        "col6": "Дата",
        "previous-text": "<",
        "next-text": ">",
        "first-text": "<<",
        "last-text": ">>"
    }

    var en_translations = {
        "language": "Language",
        "col1": "Country",
        "col2": "City",
        "col3": "Street",
        "col4": "House",
        "col5": "Index",
        "col6": "Date",
    }
    $translateProvider.translations('ru', ru_translations);

    $translateProvider.translations('en', en_translations);

    $translateProvider.preferredLanguage('ru');

}]);


AngularApp.controller("EmpCtrl",["$scope","$http","$translate", function ($scope, $http, $translate) {
    $scope.sortType = 'Id'; // значение сортировки по умолчанию
    $scope.sortReverse = false;  // обратная сортировка
    $scope.adress = "";

    $scope.functionThatReturnsColor1 = function () {
        var style1 = "color: blue";
        var style2 = "color: black";
        if (($scope.sortType == 'Id' && !$scope.sortReverse) || ($scope.sortType == 'Id' && $scope.sortReverse))
            return style1;
        else
            return style2;
    }
    $scope.functionThatReturnsColor2 = function () {
        var style1 = "color: blue";
        var style2 = "color: black";
        if (($scope.sortType == 'Country' && !$scope.sortReverse) || ($scope.sortType == 'Country' && $scope.sortReverse) || ($scope.f.Country !=""))
            return style1;
        else
            return style2;
    }
    $scope.functionThatReturnsColor3 = function () {
        var style1 = "color: blue";
        var style2 = "color: black";
        if (($scope.sortType == 'City' && !$scope.sortReverse) || ($scope.sortType == 'City' && $scope.sortReverse))
            return style1;
        else
            return style2;
    }
    $scope.functionThatReturnsColor4 = function () {
        var style1 = "color: blue";
        var style2 = "color: black";
        if (($scope.sortType == 'Street' && !$scope.sortReverse) || ($scope.sortType == 'Street' && $scope.sortReverse))
            return style1;
        else
            return style2;
    }
    $scope.functionThatReturnsColor5 = function () {
        var style1 = "color: blue";
        var style2 = "color: black";
        if (($scope.sortType == 'House' && !$scope.sortReverse) || ($scope.sortType == 'House' && $scope.sortReverse))
            return style1;
        else
            return style2;
    }
    $scope.functionThatReturnsColor6 = function () {
        var style1 = "color: blue";
        var style2 = "color: black";
        if (($scope.sortType == 'Index' && !$scope.sortReverse) || ($scope.sortType == 'Index' && $scope.sortReverse))
            return style1;
        else
            return style2;
    }
    $scope.functionThatReturnsColor7 = function () {
        var style1 = "color: blue";
        var style2 = "color: black";
        if (($scope.sortType == 'Date' && !$scope.sortReverse) || ($scope.sortType == 'Date' && $scope.sortReverse))
            return style1;
        else
            return style2;
    }
    $scope.numPerPage = 100;
    //получаем данные
    $http.get("/Home/GetAllMailAdress")
    .success(function (result) {
        $scope.adress = result;
    })
    .error(function (result) {
        console.log(result);
    });
    
    //плагинация
    $scope.pagination =
    {
    totalItems: $scope.adress.length,
    currentPage: 1,
    numPerPage: 100
    };
    $scope.paginate = function (value) {
        var start, end, index;
        start = ($scope.pagination.currentPage - 1) * $scope.pagination.numPerPage;
        end = start + $scope.pagination.numPerPage;
        index = $scope.adress.indexOf(value);
        return (start <= index && index < end);
    };

    //локализация
    $scope.changeLanguage = function (lang) {
        $translate.use("ru");
        //получаем данные
        $http.get("/Home/GetAllMailAdress")
        .success(function (result) {
            $scope.adress = result;
        })
        .error(function (result) {
            console.log(result);
        });
      
    }
    //локализация
    $scope.changeLanguage2 = function (lang) {
        $translate.use("en");
        //получаем данные
        $http.get("/Home/GetAllMailAdressEN")
        .success(function (result) {
            $scope.adress = result;
        })
        .error(function (result) {
            console.log(result);
        });
      
    }
}]);

