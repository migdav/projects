-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 25, 2020 at 08:25 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `transferapp`
--

-- --------------------------------------------------------

--
-- Table structure for table `migrations`
--

CREATE TABLE `migrations` (
  `id` int(10) UNSIGNED NOT NULL,
  `migration` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `batch` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `migrations`
--

INSERT INTO `migrations` (`id`, `migration`, `batch`) VALUES
(1, '2014_10_12_000000_create_transfers_table', 1),
(2, '2014_10_12_000000_create_users_table', 1);

-- --------------------------------------------------------

--
-- Table structure for table `transfers`
--

CREATE TABLE `transfers` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `from_userID` int(11) NOT NULL,
  `to_userID` int(11) NOT NULL,
  `amount` double(7,2) NOT NULL,
  `transfer_type` int(11) NOT NULL,
  `description` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `transfers`
--

INSERT INTO `transfers` (`id`, `from_userID`, `to_userID`, `amount`, `transfer_type`, `description`, `created_at`, `updated_at`) VALUES
(43, 6, 5, 67.00, 0, 'už programavimo kursus I', '2020-06-25 02:39:16', '2020-06-25 02:39:16'),
(44, 5, 6, 67.00, 1, 'už programavimo kursus I', '2020-06-25 02:39:16', '2020-06-25 02:39:16'),
(45, 6, 4, 120.00, 0, 'už masažo seriją 8x', '2020-06-25 02:40:09', '2020-06-25 02:40:09'),
(46, 4, 6, 120.00, 1, 'už masažo seriją 8x', '2020-06-25 02:40:09', '2020-06-25 02:40:09'),
(47, 6, 5, 81.00, 0, 'už foto albumą \"Foto centras\"', '2020-06-25 02:41:11', '2020-06-25 02:41:11'),
(48, 5, 6, 81.00, 1, 'už foto albumą \"Foto centras\"', '2020-06-25 02:41:11', '2020-06-25 02:41:11'),
(49, 4, 6, 800.00, 0, 'už skalbimo mašiną per skelbiu.lt', '2020-06-25 02:43:17', '2020-06-25 02:43:17'),
(50, 6, 4, 800.00, 1, 'už skalbimo mašiną per skelbiu.lt', '2020-06-25 02:43:17', '2020-06-25 02:43:17');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `email` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `iban` varchar(255) COLLATE utf8mb4_unicode_ci NOT NULL,
  `total` double(7,2) NOT NULL DEFAULT 1000.00,
  `created_at` timestamp NULL DEFAULT NULL,
  `updated_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `email`, `password`, `iban`, `total`, `created_at`, `updated_at`) VALUES
(4, 'petrauskas.petras@asd.com', '$2y$10$Si7KBRYewnSRlnTw7Oa6Qe5xQF0AI.nSeUzi.4RuCIkcp9S9Okhzq', 'LT519260487589832367', 320.00, '2020-06-25 02:36:49', '2020-06-25 02:43:17'),
(5, 'davidaviciute.migle@gmail.com', '$2y$10$6F6JO8IaNEFx2O6HmGhTiucoyhMYJOPtPDo04hBrA7PrL/pUL9HKi', 'LT618676624949931458', 1148.00, '2020-06-25 02:37:54', '2020-06-25 02:41:11'),
(6, 'eglekar123@yahoo.com', '$2y$10$wOJqBNcJw7Fwz3N3dnhaO.F4GSohcE1/TLaOHVHZ8S4GPEL70zWjC', 'LT758545390198072295', 1532.00, '2020-06-25 02:38:31', '2020-06-25 02:43:17');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `migrations`
--
ALTER TABLE `migrations`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `transfers`
--
ALTER TABLE `transfers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `users_email_unique` (`email`),
  ADD UNIQUE KEY `users_iban_unique` (`iban`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `migrations`
--
ALTER TABLE `migrations`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `transfers`
--
ALTER TABLE `transfers`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
