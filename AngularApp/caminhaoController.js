var app = angular.module('app', []);

app.controller('caminhaoController', ['$scope', '$http', caminhaoController]);

function caminhaoController($scope, $http) {
    $http.get('https://localhost:7012/api/Caminhao/ListarCaminhoes').success(function (data) {
        $scope.listaCaminhoes = data;
    }).erro(function () {
        $scope.erro = "Erro: Não foi possível carregar a listagem de Caminhoes.";
    });
}