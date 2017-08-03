angular.module('whoisApp', []).controller('mainController', mainCtrlFunction);

function mainCtrlFunction($http) {
    var ctrl = this;

    ctrl.urlBusca = '';
    ctrl.viewModel = null;

    ctrl.buscar = _buscar;

    function _buscar() {
        var url = 'http://localhost/Umbler/api/Buscar?dominio=' + ctrl.urlBusca;

        $http.get(url).then(function (response) {
            ctrl.viewModel = response.data;
        });
    }
}