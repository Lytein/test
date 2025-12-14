# store_management_WebAPI

10 Chức năng cho hệ thống store_management

1️. Quản lý Users (đăng nhập cho nhân viên)

	Bảng: users
	Chức năng:

	Đăng ký nhân viên

	Đăng nhập (login)

	Cấp quyền (role: admin, staff)

	Khóa / mở khóa tài khoản

	CRUD nhân viên

2️. Quản lý Customers (khách hàng)

	Bảng: customers
	Chức năng:

	Thêm khách hàng

	Chỉnh sửa khách hàng

	Xóa

	Tìm kiếm + Filter (theo sđt, tên)

	Lịch sử mua hàng (join với Orders)
3️. Quản lý Products (sản phẩm)

	Bảng: products
	Chức năng:

	Thêm sản phẩm

	Sửa sản phẩm

	Xóa

	Tìm kiếm theo tên

	Filter theo category, price range

	Quản lý hình ảnh sản phẩm
4. Quản lý Categories (danh mục sản phẩm)

	Bảng: categories
	Chức năng:

	Thêm danh mục

	Sửa

	Xóa

	Kiểm tra danh mục đang có sản phẩm hay không

	Filter sản phẩm theo danh mục
5. Quản lý Suppliers (nhà cung cấp)

	Bảng: suppliers
	Chức năng:

	Thêm nhà cung cấp

	Sửa

	Xóa

	Tìm kiếm / Filter

	Liên kết sản phẩm theo nhà cung cấp
6️. Quản lý Inventory (tồn kho)

	Bảng: inventory
	Chức năng:

	Nhập kho: tăng số lượng

	Xuất kho: giảm số lượng

	Thống kê tồn kho

	Cảnh báo hết hàng

	Lịch sử nhập/xuất (nếu bạn thêm bảng log)
7️. Quản lý Orders (đơn hàng)

	Bảng: orders
	Chức năng:

	Tạo đơn hàng

	Xem danh sách đơn

	Sửa trạng thái đơn (Pending, Paid, Cancelled)

	Xem chi tiết đơn hàng (order_items)

	Filter theo ngày, theo khách hàng
8️. Quản lý Order Items

	Bảng: order_items
	Chức năng:

	Tự tạo khi tạo đơn hàng

	Cập nhật số lượng

	Tính tổng tiền đơn tự động

	Xóa SP khỏi đơn

	Liên kết → products + orders

	(Thường xử lý trong service Order, không cần UI riêng.)
9️. Quản lý Promotions (mã giảm giá)

	Bảng: promotions
	Chức năng:

	Tạo mã giảm giá

	Sửa

	Xóa

	Apply vào đơn hàng (order)

	Kiểm tra ngày bắt đầu – hết hạn

	Điều kiện sử dụng (min order amount)
10. Quản lý Payments (thanh toán)

	Bảng: payments
	Chức năng:

	Tạo thông tin thanh toán

	Lưu lịch sử thanh toán

	Ghi nhận payment method: cash, card, e-wallet

	Filter theo ngày

	Liên kết với orders