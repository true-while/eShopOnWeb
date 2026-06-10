// Site-wide JavaScript for eShopOnWeb

(function () {
    'use strict';

    // Enforce minimum quantity of 1 on basket quantity inputs
    document.addEventListener('DOMContentLoaded', function () {
        var quantityInputs = document.querySelectorAll('input.esh-basket-input[type="number"]');
        quantityInputs.forEach(function (input) {
            input.addEventListener('change', function () {
                var value = parseInt(this.value, 10);
                if (isNaN(value) || value < 0) {
                    this.value = 0;
                }
            });
        });

        // Auto-submit catalog filter form when a select changes
        var filterSelects = document.querySelectorAll('.esh-catalog-filter select');
        filterSelects.forEach(function (select) {
            select.addEventListener('change', function () {
                var form = this.closest('form');
                if (form) {
                    form.submit();
                }
            });
        });
    });
}());

