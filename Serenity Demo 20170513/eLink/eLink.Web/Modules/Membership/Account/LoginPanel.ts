namespace eLink.Membership {

    @Serenity.Decorators.registerClass()
    export class LoginPanel extends Serenity.PropertyPanel<LoginRequest, any> {

        protected getFormKey() { return LoginForm.formKey; }

        private form: LoginForm;

        constructor(container: JQuery) {
            super(container);

            $(function () {
                ($('body') as any).vegas({
                    delay: 10000,
                    cover: true,
                    overlay: Q.resolveUrl("~/scripts/vegas/overlays/01.png"),
                    slides: [
                        { src: Q.resolveUrl('~/content/site/slides/slide1.jpg'), transition: 'fade' },
                        { src: Q.resolveUrl('~/content/site/slides/slide2.jpg'), transition: 'fade' },
                        { src: Q.resolveUrl('~/content/site/slides/slide3.jpg'), transition: 'zoomOut' },
                        { src: Q.resolveUrl('~/content/site/slides/slide4.jpg'), transition: 'blur' },
                        { src: Q.resolveUrl('~/content/site/slides/slide5.jpg'), transition: 'swirlLeft' }
                    ]
                });
            });

            this.form = new LoginForm(this.idPrefix);

            this.byId('LoginButton').click(e => {
                e.preventDefault();

                if (!this.validateForm()) {
                    return;
                }

                var request = this.getSaveEntity();
                Q.serviceCall({
                    url: Q.resolveUrl('~/Account/Login'),
                    request: request,
                    onSuccess: function (response) {
                        var q = Q.parseQueryString();
                        var returnUrl = q['returnUrl'] || q['ReturnUrl'];
                        if (returnUrl) {

                            Q.confirm(
                                "· Thông báo gửi hàng phải được gửi cho Kho Trung Chuyển trước 15:00 PM vào các ngày làm việc. (Ngày làm việc: Thứ Hai - Thứ Bảy trừ Chủ Nhật và Ngày Lễ)\r\n"
                                + "· Kho Trung Chuyển sẽ xác nhận Thông báo gửi hàng cho NCC trong vòng 1 giờ làm việc. Nếu NCC không nhận được xác nhận từ Kho Trung Chuyển trong khoảng thời gian đó thì NCC gọi Kho Trung Chuyển để yêu cầu xác nhận.\r\n"
                                + "· Hàng hóa và chứng từ phải được giao tại Kho Trung Chuyển vào ngày làm việc tiếp theo trong khung thời gian ấn định.\r\n"
                                + "· Khi giao hàng cho Kho Trung Chuyển, NCC phải xuất trình Thông báo gửi hàng có xác nhận của Kho Trung Chuyển, Bản sao hóa đơn GTGT, Đơn đặt hàng của Kho Trung Chuyển, cũng như các chứng từ theo hàng khác.\r\n"
                                + "· Kho Trung Chuyển sẽ không nhận hàng mà không có Thông báo gửi hàng có xác nhận của Kho Trung Chuyển hoặc có Thông báo gửi hàng mà không có xác nhận của Kho Trung Chuyển.",
                                () => {
                                    window.location.href = returnUrl;

                                }, { title: "Thông báo" });

                        }
                        else {
                            window.location.href = Q.resolveUrl('~/');

                        }
                    }
                });

            });
        }
    }
}