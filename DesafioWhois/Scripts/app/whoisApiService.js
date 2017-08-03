// ReSharper disable InconsistentNaming
(function () {
    'use strict';

    angular.module('whoisApp').service('whoisApiService', whoisApiService);

    function whoisApiService($http, apiUrls) {
        this.buscarPorDominio = _buscarPorDominio;
        this.atualizarCache = _atualizarCache;

        function _buscarPorDominio(dominio) {
            const url = apiUrls.busca + '?dominio=' + dominio;
            return $http.get(url);
        }

        function _atualizarCache(id) {
            const url = apiUrls.atualizarCache + '?idRegistro=' + id;
            return $http.post(url);
        }
    }
})();