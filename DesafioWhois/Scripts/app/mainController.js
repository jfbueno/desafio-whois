// ReSharper disable InconsistentNaming
(function () {
    angular.module('whoisApp').controller('mainController', mainCtrlFunction);

    function mainCtrlFunction(whoisApiService) {
        var ctrl = this;

        ctrl.urlBusca = '';
        ctrl.viewModel = null;
        ctrl.buscar = _buscar;
        ctrl.atualizarCache = _atualizarCache;
        ctrl.erro = false;

        function _buscar() {
            ctrl.erro = false;

            whoisApiService.buscarPorDominio(ctrl.urlBusca).then(function (response) {
                ctrl.viewModel = response.data;
            }).catch(function (erro) {
                ctrl.viewModel = null;
                ctrl.erro = erro.data;
            });
        }

        function _atualizarCache() {
            if (!ctrl.viewModel.Dado)
                return;

            ctrl.erro = false;

            whoisApiService.atualizarCache(ctrl.viewModel.Dado.Id).then(function (response) {
                ctrl.viewModel = response.data;
            }).catch(function (erro) {
                ctrl.erro = erro.data;
                ctrl.viewModel = null;
            });
        }
    }
})();