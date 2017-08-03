// ReSharper disable InconsistentNaming
(function () {
    angular.module('whoisApp').controller('mainController', mainCtrlFunction);

    function mainCtrlFunction(whoisApiService) {
        var ctrl = this;

        ctrl.urlBusca = '';
        ctrl.viewModel = null;
        ctrl.erro = false;
        ctrl.carregando = false;

        ctrl.buscar = _buscar;
        ctrl.atualizarCache = _atualizarCache;

        function _buscar() {
            ctrl.erro = false;
            ctrl.carregando = true;

            whoisApiService.buscarPorDominio(ctrl.urlBusca).then(function (response) {
                ctrl.viewModel = response.data;
            }).catch(function (erro) {
                ctrl.viewModel = null;
                ctrl.erro = erro.data;
            }).finally(function() {
                ctrl.carregando = false;
            });
        }

        function _atualizarCache() {
            if (!ctrl.viewModel.Dado)
                return;

            ctrl.erro = false;
            ctrl.carregando = true;

            whoisApiService.atualizarCache(ctrl.viewModel.Dado.Id).then(function (response) {
                ctrl.viewModel = response.data;
            }).catch(function (erro) {
                ctrl.erro = erro.data;
                ctrl.viewModel = null;
            }).finally(function() {
                ctrl.carregando = false;
            });
        }
    }
})();