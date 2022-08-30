-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Mar 02, 2022 at 01:08 PM
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
-- Table structure for table `ATLIKEJAS`
--

CREATE TABLE `ATLIKEJAS` (
  `id` int(11) NOT NULL,
  `vardas` varchar(255) DEFAULT NULL,
  `pavarde` varchar(255) DEFAULT NULL,
  `zanras` varchar(255) DEFAULT NULL,
  `kontaktai` varchar(255) DEFAULT NULL,
  `lytis` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ATLIKEJAS`
--

INSERT INTO `ATLIKEJAS` (`id`, `vardas`, `pavarde`, `zanras`, `kontaktai`, `lytis`) VALUES
(1, 'Elton', 'John', 'Pop / rock', 'Asmuo nepateike kontaktu', 1),
(2, 'Elvis', 'Presley', 'Rock and roll / pop / country', 'tel.: +3706000000\r\nEl.pastas:Elvis@preslis.com', 1),
(3, 'Led', 'Zeppelin', 'Hard rock / blues rock / folk rock', 'Asmuo nepateike kontaktu', 1),
(4, 'Madonna', NULL, 'Pop / dance / electronica', 'Vadybininkas:\r\nAurimas\r\n+37062577777', 2),
(5, 'Pink', 'Floyd', 'Progressive rock / psychedelic rock', '', 1),
(6, 'Rihanna', NULL, 'R&B / pop / dance / hip-hop', 'Vadybininkas:\r\nalgis@vad.com', 2),
(7, 'The Beatles', NULL, 'Rock / pop', '+37067777777', 1),
(8, 'Eminem', NULL, 'Hip-hop', 'Nera', 1),
(9, 'Mariah', 'Carey', 'R&B / pop / soul / hip-hop', 'Bus veliau', 2),
(10, 'Taylor', 'Swift', 'Pop / country / rock / folk / alternative', NULL, 2),
(11, 'Queen', NULL, 'Rock', 'Buckingham palace', 1),
(12, 'Whitney', 'Houston', 'R&B / soul / pop / gospel', NULL, 2),
(13, 'Eagles', NULL, 'Rock', NULL, NULL),
(14, 'Celine', 'Dion', 'Pop/Rock', '869935951', 2),
(15, 'AC/DC', NULL, 'Hard rock / blues rock / rock and roll', 'Australia', 1),
(16, 'The Rolling Stones', NULL, 'Rock / blues rock', NULL, 1),
(17, 'Kanye', 'West', 'Hip-hop / electronic / pop', NULL, 1),
(18, 'ABBA', NULL, 'Pop /disco', NULL, NULL),
(19, 'Bruno', 'Mars', 'Pop rock / R&B', 'Pateiks veliau', 1),
(20, 'Beyoncé', NULL, 'R&B / pop', NULL, 2),
(21, 'Michael', 'Jackson', 'Pop / rock / dance / soul / R&B', '860000000', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `ATLIKEJAS`
--
ALTER TABLE `ATLIKEJAS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `lytis` (`lytis`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ATLIKEJAS`
--
ALTER TABLE `ATLIKEJAS`
  ADD CONSTRAINT `atlikejas_ibfk_1` FOREIGN KEY (`lytis`) REFERENCES `Lytis` (`id_Lytis`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
