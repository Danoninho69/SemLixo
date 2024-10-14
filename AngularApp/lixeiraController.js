var app = angular.module('app', []);

app.controller('lixeiraController', ['$scope', '$http', lixeiraController]);

function lixeiraController($scope, $http) {
    $http.get('https://localhost:7012/api/Lixeira/ListarLixeira').success(function (data) {
        $scope.listaLixeira = data;
    }).erro(function () {
        $scope.erro = "Erro: Não foi possível carregar a listagem de Lixeira.";
    });
} 