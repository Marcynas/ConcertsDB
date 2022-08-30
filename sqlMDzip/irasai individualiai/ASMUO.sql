-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Mar 02, 2022 at 01:10 PM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `KoncertaiPrograma`
--

-- --------------------------------------------------------

--
-- Table structure for table `ASMUO`
--

CREATE TABLE `ASMUO` (
  `id` int(11) NOT NULL,
  `vardas` varchar(255) DEFAULT NULL,
  `pavarde` varchar(255) DEFAULT NULL,
  `lytis` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ASMUO`
--

INSERT INTO `ASMUO` (`id`, `vardas`, `pavarde`, `lytis`) VALUES
(1, 'Tomas', 'Paulauskas', 1),
(2, 'Tomas', 'Klimaitis', 1),
(3, 'Andrius', 'Rodkinas', 1),
(4, 'Saule', 'Petrauskaite', 2),
(5, 'Ausra', 'Stepan', 2),
(6, 'Lukas', 'Malcius', 1),
(7, 'Kristijonas', 'Donelaitis', 1),
(8, 'Arturas', 'Vejas', 1),
(9, 'Vardenis', 'Pavardenis', 1),
(10, 'Ona', 'Uoga', 2),
(11, 'Luka', 'Skoniene', 2),
(12, 'Vaidas', 'Vaidenis', 1),
(13, 'Meta', 'Lapienene', 2),
(14, 'Vygantas', 'Vanagas', 1),
(15, 'Kornelija', 'Petraitiene', 2),
(16, 'Ona', 'Smailiene', 2),
(17, 'Pertras', 'Ambrauskas', 1),
(18, 'Vytautas', 'Didziulis', 1),
(19, 'Virgis', 'Daktaras', 1),
(20, 'Rasa', 'Paukstyte', 2);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ASMUO`
--
ALTER TABLE `ASMUO`
  ADD PRIMARY KEY (`id`),
  ADD KEY `lytis` (`lytis`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ASMUO`
--
ALTER TABLE `ASMUO`
  ADD CONSTRAINT `asmuo_ibfk_1` FOREIGN KEY (`lytis`) REFERENCES `Lytis` (`id_Lytis`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
