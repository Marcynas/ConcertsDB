-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Mar 02, 2022 at 02:18 PM
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

-- --------------------------------------------------------

--
-- Table structure for table `DARBAS`
--

CREATE TABLE `DARBAS` (
  `id` int(11) NOT NULL,
  `pradzia` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `pabaiga` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `alga` float DEFAULT NULL,
  `sumoketa` float DEFAULT NULL,
  `fk_DARBUOTOJASid` int(11) NOT NULL,
  `fk_KONCERTASid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `DARBAS`
--

INSERT INTO `DARBAS` (`id`, `pradzia`, `pabaiga`, `alga`, `sumoketa`, `fk_DARBUOTOJASid`, `fk_KONCERTASid`) VALUES
(2, '1981-05-07 16:50:58', '2012-10-13 18:36:10', 1215.66, 2409.33, 14, 16),
(3, '1976-02-11 09:50:36', '1975-11-21 03:55:55', 1183.58, 1707.7, 12, 12),
(4, '1988-09-14 19:08:00', '1991-06-16 19:39:10', 1006.32, 1103.24, 42, 37),
(5, '2018-06-09 17:07:45', '1983-12-19 21:49:36', 1439, 1970.25, 19, 26),
(7, '1975-08-17 04:07:11', '1998-10-08 23:51:52', 1654.65, 1351.13, 31, 31),
(10, '1998-06-17 22:43:19', '1972-08-19 15:42:36', 1884.08, 1960.1, 44, 44),
(11, '2014-01-12 02:18:10', '1991-09-01 02:40:03', 1868.52, 2071, 46, 48),
(12, '2021-04-11 20:46:47', '2018-09-13 18:29:10', 2411.32, 2668.42, 36, 35),
(13, '1981-07-29 00:52:28', '1992-04-24 11:20:16', 2994.85, 0, 6, 3),
(15, '2018-08-23 12:16:59', '1977-01-21 07:51:22', 2884.23, 2209.5, 9, 4),
(20, '2017-07-04 06:41:48', '1994-12-24 08:53:23', 1209.07, 2610.67, 48, 49),
(25, '2014-07-02 19:06:57', '1984-04-10 07:41:47', 1025.43, 0, 43, 42),
(33, '1985-05-13 02:34:14', '2018-10-22 14:27:39', 2234.34, 0, 10, 7),
(35, '1989-12-25 08:43:45', '1997-10-05 10:45:50', 1292.14, 0, 25, 27),
(37, '2004-07-08 19:53:40', '2008-04-26 13:59:26', 1161.06, 2604.05, 15, 18),
(38, '2007-05-07 15:49:44', '2015-04-04 05:55:37', 1044.31, 1390.08, 45, 45),
(43, '1990-03-19 14:41:40', '2016-12-08 20:54:04', 1396, 0, 29, 30),
(45, '1970-05-13 04:30:07', '1971-09-01 21:05:24', 1235, 2341.37, 17, 24),
(47, '1997-03-30 15:53:31', '2002-06-29 15:54:29', 2521, 1593.26, 13, 13),
(48, '1988-01-03 18:43:35', '2017-08-21 13:31:17', 2598, 0, 28, 29);

-- --------------------------------------------------------

--
-- Table structure for table `DARBUOTOJAS`
--

CREATE TABLE `DARBUOTOJAS` (
  `id` int(11) NOT NULL,
  `dirbaNuo` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `dirbaIki` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `Darbuotojo_role` int(11) DEFAULT NULL,
  `fk_ASMUOid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `DARBUOTOJAS`
--

INSERT INTO `DARBUOTOJAS` (`id`, `dirbaNuo`, `dirbaIki`, `Darbuotojo_role`, `fk_ASMUOid`) VALUES
(6, '2022-03-02 12:49:30', '2021-12-08 15:55:58', 1, 6),
(9, '2022-03-02 12:49:30', '2021-04-27 18:10:35', 2, 13),
(10, '2022-03-02 12:49:30', '2021-04-13 22:08:04', 3, 1),
(12, '2022-03-02 12:49:30', '2021-11-03 04:28:35', 5, 7),
(13, '2022-03-02 12:49:30', '2021-03-25 10:24:55', 1, 8),
(14, '2022-03-02 12:49:30', '2021-08-21 08:33:04', 4, 4),
(15, '2022-03-02 12:49:30', '2021-06-13 17:08:54', 4, 9),
(17, '2022-03-02 12:49:30', '2021-07-06 07:21:07', 1, 5),
(19, '2022-03-02 12:49:30', '2021-05-14 00:07:48', 2, 12),
(25, '2022-03-02 12:49:30', '2021-11-18 07:33:18', 5, 3),
(28, '2022-03-02 12:49:30', '2021-12-05 03:35:59', 5, 18),
(29, '2022-03-02 12:49:30', '2021-03-18 15:10:42', 1, 17),
(31, '2022-03-02 12:49:30', '2021-06-24 11:46:51', 3, 14),
(36, '2022-03-02 12:49:30', '2021-03-09 16:36:16', 3, 16),
(42, '2022-03-02 12:49:30', '2021-06-29 15:48:40', 5, 11),
(43, '2022-03-02 12:49:30', '2021-04-28 08:52:52', 4, 10),
(44, '2022-03-02 12:49:30', '2021-11-09 13:09:32', 2, 20),
(45, '2022-03-02 12:49:30', '2022-01-15 14:39:35', 3, 2),
(46, '2022-03-02 12:49:30', '2021-11-19 14:32:24', 2, 15),
(48, '2022-03-02 12:49:30', '2021-05-21 10:22:18', 2, 19);

-- --------------------------------------------------------

--
-- Table structure for table `IRANGA`
--

CREATE TABLE `IRANGA` (
  `id` int(11) NOT NULL,
  `kiekis` int(11) DEFAULT NULL,
  `kaina` float DEFAULT NULL,
  `sumoketa` float DEFAULT NULL,
  `fk_IRENGiNYSid` int(11) NOT NULL,
  `fk_KONCERTASid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `IRANGA`
--

INSERT INTO `IRANGA` (`id`, `kiekis`, `kaina`, `sumoketa`, `fk_IRENGiNYSid`, `fk_KONCERTASid`) VALUES
(2, 9, 71.8942, 95.647, 13, 24),
(7, 8, 34.9145, 99.1724, 43, 44),
(8, 3, 54.0411, 57.948, 10, 16),
(10, 8, 58, 61.4899, 44, 45),
(15, 8, 84, 85.406, 6, 12),
(16, 6, 64.4756, 95.553, 31, 42),
(18, 10, 54.7177, 59.21, 15, 26),
(19, 9, 39.5005, 73.0113, 49, 49),
(25, 10, 83.1467, 64.9655, 2, 3),
(26, 4, 30.623, 83.5143, 3, 4),
(28, 6, 88.36, 96.533, 22, 30),
(29, 6, 21.539, 74, 30, 37),
(32, 10, 21.66, 93.882, 12, 18),
(33, 6, 79.2, 54.1143, 9, 13),
(34, 6, 32.5212, 92.8755, 29, 35),
(35, 3, 86, 66.5327, 21, 29),
(36, 7, 98.409, 90.1241, 23, 31),
(38, 2, 57.9471, 57.6, 46, 48),
(42, 8, 22.747, 63.169, 5, 7),
(50, 6, 40.1503, 95, 16, 27);

-- --------------------------------------------------------

--
-- Table structure for table `IRENGINIO_TIPAS`
--

CREATE TABLE `IRENGINIO_TIPAS` (
  `id` int(11) NOT NULL,
  `tipas` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `IRENGINIO_TIPAS`
--

INSERT INTO `IRENGINIO_TIPAS` (`id`, `tipas`) VALUES
(19, 1),
(21, 1),
(22, 1),
(31, 1),
(14, 2),
(16, 2),
(25, 2),
(37, 2),
(2, 3),
(12, 3),
(26, 3),
(15, 4),
(48, 4),
(50, 4),
(7, 5),
(13, 5),
(47, 5),
(24, 6),
(30, 6),
(41, 6);

-- --------------------------------------------------------

--
-- Table structure for table `IRENGiNYS`
--

CREATE TABLE `IRENGiNYS` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL,
  `turimas_kiekis` float DEFAULT NULL,
  `fk_IRENGINIO_TIPASid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `IRENGiNYS`
--

INSERT INTO `IRENGiNYS` (`id`, `pavadinimas`, `turimas_kiekis`, `fk_IRENGINIO_TIPASid`) VALUES
(2, '14mc8tl', 2, 15),
(3, '14zs0ee', 3, 31),
(5, '39uo5yn', 2, 12),
(6, '26pv9pq', 1, 48),
(9, '32co9na', 9, 30),
(10, '03pk2dz', 1, 21),
(12, '22wc5mh', 10, 37),
(13, '97rk1gm', 8, 14),
(15, '33bq8lr', 2, 22),
(16, '21gb0wg', 10, 26),
(21, '27ml7hh', 4, 19),
(22, '66qn4ec', 2, 2),
(23, '96px4xo', 6, 16),
(29, '38ov2vw', 6, 41),
(30, '22qr5ab', 3, 24),
(31, '83vv3ti', 10, 47),
(43, '41kb4dt', 1, 50),
(44, '41uh2mf', 5, 25),
(46, '34xk6tp', 8, 7),
(49, '15pm4pr', 5, 13);

-- --------------------------------------------------------

--
-- Table structure for table `KONCERTAS`
--

CREATE TABLE `KONCERTAS` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL,
  `pradzia` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `pabaiga` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `aprasymas` varchar(255) DEFAULT NULL,
  `miestas` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `KONCERTAS`
--

INSERT INTO `KONCERTAS` (`id`, `pavadinimas`, `pradzia`, `pabaiga`, `aprasymas`, `miestas`) VALUES
(3, 'Rerum qui aliquid.', '2022-03-02 13:18:01', '2021-06-05 11:20:52', 'Alice, who was sitting on a three-legged stool in the distance, sitting sad and lonely on a three-legged stool in the last few minutes, and began picking them up again with a table set out under a.', 1),
(4, 'Voluptas in aut cumque.', '2022-03-02 13:18:01', '2021-07-21 11:01:12', '', 1),
(7, 'Rerum sint.', '2022-03-02 13:18:01', '2021-03-18 22:01:18', 'HE was.\' \'I never went to school in the sand with wooden spades, then a great hurry to get rather sleepy, and went by without noticing her. Then followed the Knave of Hearts, and I never knew.', 2),
(12, 'Quos autem asperiores sint.', '2022-03-02 13:18:01', '2021-06-05 16:17:25', 'Alice said to the three gardeners at it, and burning with curiosity, she ran off as hard as she spoke--fancy CURTSEYING as you\'re falling through the wood. \'If it had been. But her sister sat still.', 7),
(13, 'Molestiae aspernatur cumque nostrum.', '2022-03-02 13:18:01', '2021-03-12 17:05:54', 'Alice in a coaxing tone, and added with a little door about fifteen inches high: she tried hard to whistle to it; but she thought it must be Mabel after all, and I had to stop and untwist it. After.', 8),
(16, 'Odit quod et quia.', '2022-03-02 13:18:01', '2021-05-25 00:11:25', 'Why, I haven\'t been invited yet.\' \'You\'ll see me there,\' said the Dormouse; \'--well in.\' This answer so confused poor Alice, who felt very glad to do it?\' \'In my youth,\' said the White Rabbit.', 6),
(18, 'Sed inventore dolor nobis.', '2022-03-02 13:18:01', '2021-10-12 04:55:55', '', 5),
(24, 'Recusandae unde aliquid.', '2022-03-02 13:18:01', '2021-04-29 03:36:45', 'Alice\'s first thought was that you had been looking at everything that Alice said; but was dreadfully puzzled by the Queen in a deep voice, \'are done with a sigh. \'I only took the place of the song,.', 1),
(26, 'Velit qui recusandae quidem.', '2022-03-02 13:18:01', '2021-06-05 00:52:44', 'Turtle.\' These words were followed by a row of lodging houses, and behind them a new kind of serpent, that\'s all the rats and--oh dear!\' cried Alice hastily, afraid that it felt quite relieved to.', 2),
(27, 'Minus iste cum.', '2022-03-02 13:18:01', '2021-04-24 18:04:40', '', 2),
(29, 'Quos optio neque.', '2022-03-02 13:18:01', '2021-10-02 15:04:19', '', 1),
(30, 'Praesentium velit at.', '2022-03-02 13:18:01', '2021-06-02 08:50:22', '', 3),
(31, 'Magni voluptatem sunt eius.', '2022-03-02 13:18:01', '2021-09-18 08:45:23', 'Alice led the way, and nothing seems to grin, How neatly spread his claws, And welcome little fishes in With gently smiling jaws!\' \'I\'m sure I\'m not particular as to prevent its undoing itself,) she.', 14),
(35, 'Expedita voluptatem in et.', '2022-03-02 13:18:01', '2021-07-20 21:48:28', '', 7),
(37, 'Qui qui.', '2022-03-02 13:18:01', '2021-06-17 10:43:45', 'They were just beginning to get in?\' she repeated, aloud. \'I shall sit here,\' he said, \'on and off, for days and days.\' \'But what did the archbishop find?\' The Mouse did not like to go on with the.', 4),
(42, 'Qui id ducimus labore.', '2022-03-02 13:18:01', '2021-12-05 23:00:02', 'Alice noticed, had powdered hair that WOULD always get into that lovely garden. First, however, she waited patiently. \'Once,\' said the Caterpillar. This was such a rule at processions; \'and besides,.', 9),
(44, 'Soluta a accusantium iusto.', '2022-03-02 13:18:01', '2021-11-12 07:14:20', 'Alice\'s shoulder, and it was over at last: \'and I wish you wouldn\'t keep appearing and vanishing so suddenly: you make one repeat lessons!\' thought Alice; but she heard a little shaking among the.', 6),
(45, 'Ut unde qui unde.', '2022-03-02 13:18:01', '2021-03-07 13:51:57', '', 2),
(48, 'Quidem alias.', '2022-03-02 13:18:01', '2021-11-16 03:22:11', 'They had not attended to this last remark that had made the whole court was in livery: otherwise, judging by his garden.\"\' Alice did not like the Queen?\' said the Cat. \'I don\'t think--\' \'Then you.', 10),
(49, 'Similique accusantium.', '2022-03-02 13:18:01', '2021-07-13 16:41:37', 'Mock Turtle would be a queer thing, to be listening, so she began looking at everything that Alice quite jumped; but she stopped hastily, for the Duchess replied, in a low, trembling voice. \'There\'s.', 14);

-- --------------------------------------------------------

--
-- Table structure for table `Lytis`
--

CREATE TABLE `Lytis` (
  `id_Lytis` int(11) NOT NULL,
  `name` char(7) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Lytis`
--

INSERT INTO `Lytis` (`id_Lytis`, `name`) VALUES
(1, 'Vyras'),
(2, 'Moteris');

-- --------------------------------------------------------

--
-- Table structure for table `Miestas`
--

CREATE TABLE `Miestas` (
  `id_Miestas` int(11) NOT NULL,
  `name` char(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Miestas`
--

INSERT INTO `Miestas` (`id_Miestas`, `name`) VALUES
(1, 'Vilnius'),
(2, 'Kaunas'),
(3, 'Klaipeda'),
(4, 'Siauliai'),
(5, 'Panevezys'),
(6, 'Alytus'),
(7, 'Marijampole'),
(8, 'Mazeikiai'),
(9, 'Jonava'),
(10, 'Utena'),
(11, 'Kedainiai'),
(12, 'Taurage'),
(13, 'Telsiai'),
(14, 'Ukmerge');

-- --------------------------------------------------------

--
-- Table structure for table `PASIRODYMAS`
--

CREATE TABLE `PASIRODYMAS` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL,
  `kaina` float DEFAULT NULL,
  `sumoketa` float DEFAULT NULL,
  `fk_KONCERTASid` int(11) NOT NULL,
  `fk_ATLIKEJASid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `PASIRODYMAS`
--

INSERT INTO `PASIRODYMAS` (`id`, `pavadinimas`, `kaina`, `sumoketa`, `fk_KONCERTASid`, `fk_ATLIKEJASid`) VALUES
(1, 'est', 387, 383, 26, 9),
(4, 'sequi', 226, 422, 37, 15),
(6, 'voluptas', 323, 0, 13, 5),
(9, 'voluptas', 357, 363, 35, 14),
(11, 'quia', 259, 0, 31, 13),
(13, 'incidunt', 483, 306, 44, 17),
(18, 'fugit', 458, 0, 3, 1),
(19, 'hic', 100, 0, 27, 10),
(20, 'consequatur', 236, 377, 24, 8),
(22, 'facilis', 362, 488, 12, 4),
(29, 'rem', 355, 489, 7, 3),
(30, 'a', 295, 578, 49, 20),
(31, 'odio', 178, 0, 30, 12),
(34, 'quibusdam', 409, 448, 16, 6),
(35, 'eum', 199, 405, 48, 19),
(37, 'qui', 404, 0, 45, 18),
(38, 'accusantium', 316, 0, 42, 16),
(46, 'et', 241, 0, 4, 2),
(47, 'et', 198, 0, 29, 11),
(48, 'doloribus', 332, 551, 18, 7);

-- --------------------------------------------------------

--
-- Table structure for table `Role`
--

CREATE TABLE `Role` (
  `id_Role` int(11) NOT NULL,
  `name` char(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Role`
--

INSERT INTO `Role` (`id_Role`, `name`) VALUES
(1, 'Garso_indzinierius'),
(2, 'Gitaru_technikas'),
(3, 'Apsvietimo_technikas'),
(4, 'Koordinatorius'),
(5, 'Scenos_vadybininkas');

-- --------------------------------------------------------

--
-- Table structure for table `Tipas`
--

CREATE TABLE `Tipas` (
  `id_Tipas` int(11) NOT NULL,
  `name` char(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Tipas`
--

INSERT INTO `Tipas` (`id_Tipas`, `name`) VALUES
(1, 'Apsvietimas'),
(2, 'Mikrofonas'),
(3, 'Iem'),
(4, 'Laidas'),
(5, 'Kolonele'),
(6, 'Pultas');

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
-- Indexes for table `ATLIKEJAS`
--
ALTER TABLE `ATLIKEJAS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `lytis` (`lytis`);

--
-- Indexes for table `DARBAS`
--
ALTER TABLE `DARBAS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `priskirtas` (`fk_DARBUOTOJASid`),
  ADD KEY `atliekamas` (`fk_KONCERTASid`);

--
-- Indexes for table `DARBUOTOJAS`
--
ALTER TABLE `DARBUOTOJAS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Darbuotojo_role` (`Darbuotojo_role`),
  ADD KEY `yra` (`fk_ASMUOid`);

--
-- Indexes for table `IRANGA`
--
ALTER TABLE `IRANGA`
  ADD PRIMARY KEY (`id`),
  ADD KEY `reikia` (`fk_IRENGiNYSid`),
  ADD KEY `turi` (`fk_KONCERTASid`);

--
-- Indexes for table `IRENGINIO_TIPAS`
--
ALTER TABLE `IRENGINIO_TIPAS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `tipas` (`tipas`);

--
-- Indexes for table `IRENGiNYS`
--
ALTER TABLE `IRENGiNYS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `priklauso` (`fk_IRENGINIO_TIPASid`);

--
-- Indexes for table `KONCERTAS`
--
ALTER TABLE `KONCERTAS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `miestas` (`miestas`);

--
-- Indexes for table `Lytis`
--
ALTER TABLE `Lytis`
  ADD PRIMARY KEY (`id_Lytis`);

--
-- Indexes for table `Miestas`
--
ALTER TABLE `Miestas`
  ADD PRIMARY KEY (`id_Miestas`);

--
-- Indexes for table `PASIRODYMAS`
--
ALTER TABLE `PASIRODYMAS`
  ADD PRIMARY KEY (`id`),
  ADD KEY `vyksta` (`fk_KONCERTASid`),
  ADD KEY `atlieka` (`fk_ATLIKEJASid`);

--
-- Indexes for table `Role`
--
ALTER TABLE `Role`
  ADD PRIMARY KEY (`id_Role`);

--
-- Indexes for table `Tipas`
--
ALTER TABLE `Tipas`
  ADD PRIMARY KEY (`id_Tipas`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ASMUO`
--
ALTER TABLE `ASMUO`
  ADD CONSTRAINT `asmuo_ibfk_1` FOREIGN KEY (`lytis`) REFERENCES `Lytis` (`id_Lytis`);

--
-- Constraints for table `ATLIKEJAS`
--
ALTER TABLE `ATLIKEJAS`
  ADD CONSTRAINT `atlikejas_ibfk_1` FOREIGN KEY (`lytis`) REFERENCES `Lytis` (`id_Lytis`);

--
-- Constraints for table `DARBAS`
--
ALTER TABLE `DARBAS`
  ADD CONSTRAINT `atliekamas` FOREIGN KEY (`fk_KONCERTASid`) REFERENCES `KONCERTAS` (`id`),
  ADD CONSTRAINT `priskirtas` FOREIGN KEY (`fk_DARBUOTOJASid`) REFERENCES `DARBUOTOJAS` (`id`);

--
-- Constraints for table `DARBUOTOJAS`
--
ALTER TABLE `DARBUOTOJAS`
  ADD CONSTRAINT `darbuotojas_ibfk_1` FOREIGN KEY (`Darbuotojo_role`) REFERENCES `Role` (`id_Role`),
  ADD CONSTRAINT `yra` FOREIGN KEY (`fk_ASMUOid`) REFERENCES `ASMUO` (`id`);

--
-- Constraints for table `IRANGA`
--
ALTER TABLE `IRANGA`
  ADD CONSTRAINT `reikia` FOREIGN KEY (`fk_IRENGiNYSid`) REFERENCES `IRENGiNYS` (`id`),
  ADD CONSTRAINT `turi` FOREIGN KEY (`fk_KONCERTASid`) REFERENCES `KONCERTAS` (`id`);

--
-- Constraints for table `IRENGINIO_TIPAS`
--
ALTER TABLE `IRENGINIO_TIPAS`
  ADD CONSTRAINT `irenginio_tipas_ibfk_1` FOREIGN KEY (`tipas`) REFERENCES `Tipas` (`id_Tipas`);

--
-- Constraints for table `IRENGiNYS`
--
ALTER TABLE `IRENGiNYS`
  ADD CONSTRAINT `priklauso` FOREIGN KEY (`fk_IRENGINIO_TIPASid`) REFERENCES `IRENGINIO_TIPAS` (`id`);

--
-- Constraints for table `KONCERTAS`
--
ALTER TABLE `KONCERTAS`
  ADD CONSTRAINT `koncertas_ibfk_1` FOREIGN KEY (`miestas`) REFERENCES `Miestas` (`id_Miestas`);

--
-- Constraints for table `PASIRODYMAS`
--
ALTER TABLE `PASIRODYMAS`
  ADD CONSTRAINT `atlieka` FOREIGN KEY (`fk_ATLIKEJASid`) REFERENCES `ATLIKEJAS` (`id`),
  ADD CONSTRAINT `vyksta` FOREIGN KEY (`fk_KONCERTASid`) REFERENCES `KONCERTAS` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
