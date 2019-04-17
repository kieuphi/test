
var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    DonGia: $(item).val(),
                    MaSP: {
                        ID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/MuaHang/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Index/MuaHang";
                    }
                }
            })
        });

        //$('#btnDeleteAll').off('click').on('click', function () {


        //    $.ajax({
        //        url: '/Cart/DeleteAll',
        //        dataType: 'json',
        //        type: 'POST',
        //        success: function (res) {
        //            if (res.status == true) {
        //                window.location.href = "/gio-hang";
        //            }
        //        }
        //    })
        //});

        //$('.btn-delete').off('click').on('click', function (e) {
        //    e.preventDefault();
        //    $.ajax({
        //        data: { id: $(this).data('id') },
        //        url: '/Cart/Delete',
        //        dataType: 'json',
        //        type: 'POST',
        //        success: function (res) {
        //            if (res.status == true) {
        //                window.location.href = "/gio-hang";
        //            }
        //        }
        //    })
        //});
    }
}
