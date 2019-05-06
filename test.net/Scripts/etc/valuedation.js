$().ready(function () {
    //$.validator.addMethod("Email", function (value, element) {
    //           var re = /^([\w-\.]+@@([\w-]+\.)+[\w-]{2,4})?$/;

    //            return this.optional(element) || re.test(String(value).toLowerCase);
    //}, "Hãy nhập password từ 8 đến 16 ký tự bao gồm chữ hoa, chữ thường và ít nhất một chữ số");
    $('.main-grid form').validate({
        onfocusout: false,
        onkeyup: false,
        onclick: false,

        rules: {
            // san pham
            "TenSp": {
                required: true
            },
            "GiaNhap": {
                required: true,
                number: true,
            },
            "SoLuongTon": {
                required: true,
                number: true,
            },
            // nha cung cap +danh muc
            "TenNCC": {
                required: true
            },

            "TenDM": {
                required: true
            },
            "Diachi": {
                required: true,
            },
            // nhan vien +khach hang
            "TenNv": {
                required: true
            },
            "DiaChi": {
                required: true,
            },

            "Email": {
                required: true,
                email: true,
            },

            "TenKH": {
                required: true,
            },
            "Sdt": {
                required: true,
                number: true,
            },
            "Cmd": {
                number: true
            },
        },
        messages: {
            "TenNCC": {
                required: "tên chưa nhập "
            },
            "TenNv": {
                required: "tên nhân viên chưa nhập "
            },
            "DiaChi": {
                required: "địa chỉ chưa nhập",
            },
            "Diachi": {
                required: "địa chỉ chưa nhập",
            },

            "Email": {
                required: "thiếu email",
                email: "sai đinh dạng",
            },
            "TenKH": {
                required: " chưa nhập "
            },

            "Sdt": {
                required: "sdt chưa nhập chưa nhập",
                number: "sdt phải la số",
            },
            "Cmd": {
                number: "phải là số"
            },
            "TenSp": {
                required: "bạn hãy nhập tên sản phẩm "
            },
            "GiaNhap": {
                required: "giá nhập phải được nhập",
                number: "giá nhập phải la số",
            },
            "SoLuongTon": {
                required: "giá nhập phải được nhập",
                number: "giá nhập phải la số",
            },
            "TenNCC": {
                required: "thiếu"
            },

            "TenDM": {
                required: "thiếu"
            },
        }
    })
})