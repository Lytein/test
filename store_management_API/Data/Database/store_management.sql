-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th12 15, 2025 lúc 06:24 AM
-- Phiên bản máy phục vụ: 10.4.32-MariaDB
-- Phiên bản PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `store_management`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `categories`
--

CREATE TABLE `categories` (
  `category_id` int(11) NOT NULL,
  `category_name` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `categories`
--

INSERT INTO `categories` (`category_id`, `category_name`) VALUES
(1, 'Đồ uống'),
(2, 'Bánh kẹo'),
(3, 'Gia vị'),
(4, 'Đồ gia dụng'),
(5, 'Mỹ phẩm');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `customers`
--

CREATE TABLE `customers` (
  `customer_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `address` text DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `customers`
--

INSERT INTO `customers` (`customer_id`, `name`, `phone`, `email`, `address`, `created_at`) VALUES
(1, 'Nguyễn văn A', '0909000001', 'kh1@mail.com', 'Địa chỉ 1', '2025-11-27 06:21:09'),
(2, 'Khách hàng 2', '0909000002', 'kh2@mail.com', 'Địa chỉ 2', '2025-11-27 06:21:09'),
(3, 'Khách hàng 3', '0909000003', 'kh3@mail.com', 'Địa chỉ 3', '2025-11-27 06:21:09'),
(4, 'Khách hàng 4', '0909000004', 'kh4@mail.com', 'Địa chỉ 4', '2025-11-27 06:21:09'),
(5, 'Khách hàng 5', '0909000005', 'kh5@mail.com', 'Địa chỉ 5', '2025-11-27 06:21:09'),
(6, 'Khách hàng 6', '0909000006', 'kh6@mail.com', 'Địa chỉ 6', '2025-11-27 06:21:09'),
(7, 'Khách hàng 7', '0909000007', 'kh7@mail.com', 'Địa chỉ 7', '2025-11-27 06:21:09'),
(8, 'Khách hàng 8', '0909000008', 'kh8@mail.com', 'Địa chỉ 8', '2025-11-27 06:21:09'),
(9, 'Khách hàng 9', '0909000009', 'kh9@mail.com', 'Địa chỉ 9', '2025-11-27 06:21:09'),
(10, 'Khách hàng 10', '0909000010', 'kh10@mail.com', 'Địa chỉ 10', '2025-11-27 06:21:09'),
(11, 'Khách hàng 11', '0909000011', 'kh11@mail.com', 'Địa chỉ 11', '2025-11-27 06:21:09'),
(12, 'Khách hàng 12', '0909000012', 'kh12@mail.com', 'Địa chỉ 12', '2025-11-27 06:21:09'),
(13, 'Khách hàng 13', '0909000013', 'kh13@mail.com', 'Địa chỉ 13', '2025-11-27 06:21:09'),
(14, 'Khách hàng 14', '0909000014', 'kh14@mail.com', 'Địa chỉ 14', '2025-11-27 06:21:09'),
(15, 'Khách hàng 15', '0909000015', 'kh15@mail.com', 'Địa chỉ 15', '2025-11-27 06:21:09'),
(16, 'Khách hàng 16', '0909000016', 'kh16@mail.com', 'Địa chỉ 16', '2025-11-27 06:21:09'),
(17, 'Khách hàng 17', '0909000017', 'kh17@mail.com', 'Địa chỉ 17', '2025-11-27 06:21:09'),
(18, 'Khách hàng 18', '0909000018', 'kh18@mail.com', 'Địa chỉ 18', '2025-11-27 06:21:09'),
(19, 'Khách hàng 19', '0909000019', 'kh19@mail.com', 'Địa chỉ 19', '2025-11-27 06:21:09'),
(21, 'Nguyễn  rrr', '0901234567', 'aaaaq@gmail.com', '31351 Nguyen van troi', '2025-12-13 13:44:05'),
(26, 'nguyenadada', '0901234567', 'lam131@gmail.com', 'adad hcm', '2025-12-14 06:14:38'),
(27, 'Lam cam', '0901234567', 'aaaa@gmail.com', '13 hcm hn', '2025-12-14 07:41:51'),
(28, 'test334', '0901283765', 'nak@gmail.com', '3131 Ha Noi', '2025-12-14 16:25:00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `customer_accounts`
--

CREATE TABLE `customer_accounts` (
  `id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `created_at` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `customer_accounts`
--

INSERT INTO `customer_accounts` (`id`, `customer_id`, `username`, `password`, `created_at`) VALUES
(1, 21, 'nguyen21', '123456', '2025-12-14 12:50:22'),
(2, 26, 'test12', '123456', '2025-12-14 13:14:38'),
(3, 27, 'test113', 'AQAAAAIAAYagAAAAEIEtcrQYeREkZAAl3nbTkb+83g7+AH0+UZ9XiS7Zh8e1+2Uyn2GJQz0yBZKELkJzbw==', '2025-12-14 14:41:51'),
(4, 28, 'LAM', 'AQAAAAIAAYagAAAAEBXr6erHBYICk6EQGgXQu1ipms43b35sWOMrkF9q3YvxDoIgCEvRNMY85m8QSA5uzw==', '2025-12-14 23:25:00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `inventory`
--

CREATE TABLE `inventory` (
  `inventory_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) DEFAULT 0,
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `orders`
--

CREATE TABLE `orders` (
  `order_id` int(11) NOT NULL,
  `customer_id` int(11) DEFAULT NULL,
  `user_id` int(11) DEFAULT NULL,
  `promo_id` int(11) DEFAULT NULL,
  `order_date` timestamp NOT NULL DEFAULT current_timestamp(),
  `status` enum('pending','paid','canceled') DEFAULT 'pending',
  `total_amount` decimal(10,2) DEFAULT NULL,
  `discount_amount` decimal(10,2) DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `order_items`
--

CREATE TABLE `order_items` (
  `order_item_id` int(11) NOT NULL,
  `order_id` int(11) DEFAULT NULL,
  `product_id` int(11) DEFAULT NULL,
  `quantity` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `payments`
--

CREATE TABLE `payments` (
  `payment_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `amount` decimal(10,2) NOT NULL,
  `payment_method` enum('cash','card','bank_transfer','e-wallet') DEFAULT 'cash',
  `payment_date` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `products`
--

CREATE TABLE `products` (
  `product_id` int(11) NOT NULL,
  `category_id` int(11) DEFAULT NULL,
  `supplier_id` int(11) DEFAULT NULL,
  `product_name` varchar(100) NOT NULL,
  `barcode` varchar(50) DEFAULT NULL,
  `price` decimal(10,2) NOT NULL,
  `unit` varchar(20) DEFAULT 'pcs',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `products`
--

INSERT INTO `products` (`product_id`, `category_id`, `supplier_id`, `product_name`, `barcode`, `price`, `unit`, `created_at`) VALUES
(1, 1, 1, 'Nước ngọt Coca', '1234567890', 12000.00, 'chai', '2025-12-11 03:00:00'),
(2, 2, 1, 'Kẹo socola Mars', '1234567891', 8000.00, 'thanh', '2025-12-11 03:05:00'),
(3, 3, 2, 'Muối i-ốt', '1234567892', 5000.00, 'gói', '2025-12-11 03:10:00'),
(4, 4, 2, 'Chổi quét nhà', '1234567893', 35000.00, 'cái', '2025-12-11 03:15:00'),
(5, 5, 3, 'Son môi Dior', '1234567894', 250000.00, 'cây', '2025-12-11 03:20:00');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `promotions`
--

CREATE TABLE `promotions` (
  `promo_id` int(11) NOT NULL,
  `promo_code` varchar(50) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `discount_type` enum('percent','fixed') NOT NULL,
  `discount_value` decimal(10,2) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `min_order_amount` decimal(10,2) DEFAULT 0.00,
  `usage_limit` int(11) DEFAULT 0,
  `used_count` int(11) DEFAULT 0,
  `status` enum('active','inactive') DEFAULT 'active'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `suppliers`
--

CREATE TABLE `suppliers` (
  `supplier_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `address` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `suppliers`
--

INSERT INTO `suppliers` (`supplier_id`, `name`, `phone`, `email`, `address`) VALUES
(1, 'Công ty ABC', '0909123456', 'abc@gmail.com', 'Hà Nội'),
(2, 'Công ty XYZ', '0912123456', 'xyz@gmail.com', 'TP HCM'),
(3, 'Công ty 123', '0933123456', '123@gmail.com', 'Đà Nẵng');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `users`
--

CREATE TABLE `users` (
  `user_id` int(11) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `full_name` varchar(100) DEFAULT NULL,
  `role` enum('admin','staff') DEFAULT 'staff',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `users`
--

INSERT INTO `users` (`user_id`, `username`, `password`, `full_name`, `role`, `created_at`) VALUES
(1, 'admin', '123456', 'Quản trị viên', 'admin', '2025-11-27 06:21:09'),
(2, 'staff01', '123456', 'Nguyễn Văn A', 'staff', '2025-11-27 06:21:09'),
(3, 'staff02', '123456', 'Lê Thị B', 'staff', '2025-11-27 06:21:09'),
(4, 'staf00001', '1234567', 'Nguyễn Thị Bằng', 'staff', '2025-12-13 06:45:43');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`category_id`);

--
-- Chỉ mục cho bảng `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`customer_id`);

--
-- Chỉ mục cho bảng `customer_accounts`
--
ALTER TABLE `customer_accounts`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD KEY `fk_customer_account` (`customer_id`);

--
-- Chỉ mục cho bảng `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`inventory_id`);

--
-- Chỉ mục cho bảng `orders`
--
ALTER TABLE `orders`
  ADD PRIMARY KEY (`order_id`);

--
-- Chỉ mục cho bảng `order_items`
--
ALTER TABLE `order_items`
  ADD PRIMARY KEY (`order_item_id`);

--
-- Chỉ mục cho bảng `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`payment_id`);

--
-- Chỉ mục cho bảng `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`),
  ADD UNIQUE KEY `barcode` (`barcode`);

--
-- Chỉ mục cho bảng `promotions`
--
ALTER TABLE `promotions`
  ADD PRIMARY KEY (`promo_id`),
  ADD UNIQUE KEY `promo_code` (`promo_code`);

--
-- Chỉ mục cho bảng `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`supplier_id`);

--
-- Chỉ mục cho bảng `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `customers`
--
ALTER TABLE `customers`
  MODIFY `customer_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;

--
-- AUTO_INCREMENT cho bảng `customer_accounts`
--
ALTER TABLE `customer_accounts`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT cho bảng `inventory`
--
ALTER TABLE `inventory`
  MODIFY `inventory_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `orders`
--
ALTER TABLE `orders`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `order_items`
--
ALTER TABLE `order_items`
  MODIFY `order_item_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `payments`
--
ALTER TABLE `payments`
  MODIFY `payment_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `promotions`
--
ALTER TABLE `promotions`
  MODIFY `promo_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `suppliers`
--
ALTER TABLE `suppliers`
  MODIFY `supplier_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT cho bảng `users`
--
ALTER TABLE `users`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `customer_accounts`
--
ALTER TABLE `customer_accounts`
  ADD CONSTRAINT `fk_customer_account` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
