var AppModule = angular.module('AppModule', ['datatables', 'datatables.light-columnfilter', 'pascalprecht.translate',]);

AppModule.config(["$translateProvider", function ($translateProvider) {
    $translateProvider.translations('en', {
        language: "Language",
        Id: "ID",
        Country: "Country",
        City: "City",
        Street: "Street",
        House: "House",
        Index: "Index",
        Date: "Date",
        adress: "Mailing addresses"
    });
    $translateProvider.translations('ru', {
        language: "Язык",
        Id: "Номер",
        Country: "Страна",
        City: "Город",
        Street: "Улица",
        House: "Дом",
        Index: "Индекс",
        Date: "Дата",
        adress: "Почтовые адреса"
    });
    $translateProvider.preferredLanguage('ru');
}]);
AppModule.controller('homeCtrl', ['$scope', '$http', '$filter', 'DTOptionsBuilder', 'DTColumnBuilder', "$translate",
    function ($scope, $http, $filter, DTOptionsBuilder, DTColumnBuilder, $translate) {

      $scope.dtColumns = [
      DTColumnBuilder.newColumn("Id").withOption('name', 'Id'),
      DTColumnBuilder.newColumn("Country").withOption('name', 'Country'),
      DTColumnBuilder.newColumn("City").withOption('name', 'City'),
      DTColumnBuilder.newColumn("Street").withOption('name', 'Street'),
      DTColumnBuilder.newColumn("House").withOption('name', 'House'),
      DTColumnBuilder.newColumn("Index").withOption('name', 'Index'),
      DTColumnBuilder.newColumn("Date").withOption('name', 'Date').renderWith(function (data, type) {
          var dt = data.replace("/Date(", "").replace(")/", "");
          return $filter('date')(dt, 'dd.MM.yyyy'); //фильтрация даты
      })
        ]
        $scope.dtOptions = DTOptionsBuilder.newOptions().withOption('ajax', {
            dataSrc: "data",
            url: "/home/getdata",
            type: "POST"
        })
        .withOption('processing', true) //индикатора выполнения
        .withOption('serverSide', true) // обработка на стророне сервера
        .withPaginationType('full_numbers') // получаем полные параметры для разбивки на страницы
        .withDisplayLength(10) // размер пагинации
        .withOption('aaSorting', [0, 'asc']) // Для столбца сортировки, по умолчанию первый столбец
        .withDOM('lrtip') //скрываем дефолтный фильтр
           .withLightColumnFilter({
               '0': { html: 'input', type: 'text' },
               '1': { html: 'input', type: 'text' },
               '2': { html: 'input', type: 'text' },
               '3': { html: 'input', type: 'text' },
               '4': { html: 'input', type: 'text' },
               '5': { html: 'input', type: 'text' },
               '6': { html: 'input', type: 'text' },
               '7': { html: 'input', type: 'date' }
           })
        //локализация на русский
        $scope.changeLanguage = function (lang) {
            $translate.use("ru");
        }
        //локализация на английский
        $scope.changeLanguage2 = function (lang) {
            $translate.use("en");
       }
    }]);
