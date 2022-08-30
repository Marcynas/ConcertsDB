-- MariaDB dump 10.19  Distrib 10.5.12-MariaDB, for Linux (x86_64)
--
-- Host: mysql.hostinger.ro    Database: u574849695_20
-- ------------------------------------------------------
-- Server version	10.5.12-MariaDB-cll-lve

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `KONCERTAS`
--

DROP TABLE IF EXISTS `KONCERTAS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `KONCERTAS` (
  `id` int(11) NOT NULL,
  `pavadinimas` varchar(255) DEFAULT NULL,
  `pradzia` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `pabaiga` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `aprasymas` varchar(255) DEFAULT NULL,
  `miestas` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `miestas` (`miestas`),
  CONSTRAINT `koncertas_ibfk_1` FOREIGN KEY (`miestas`) REFERENCES `Miestas` (`id_Miestas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `KONCERTAS`
--

LOCK TABLES `KONCERTAS` WRITE;
/*!40000 ALTER TABLE `KONCERTAS` DISABLE KEYS */;
INSERT INTO `KONCERTAS` VALUES (3,'Rerum qui aliquid.','2021-11-12 04:58:26','2021-06-05 14:20:52','Alice, who was sitting on a three-legged stool in the distance, sitting sad and lonely on a three-legged stool in the last few minutes, and began picking them up again with a table set out under a.',NULL),(4,'Voluptas in aut cumque.','2021-12-28 15:51:31','2021-07-21 14:01:12','',NULL),(7,'Rerum sint.','2021-09-12 07:47:28','2021-03-19 00:01:18','HE was.\' \'I never went to school in the sand with wooden spades, then a great hurry to get rather sleepy, and went by without noticing her. Then followed the Knave of Hearts, and I never knew.',NULL),(12,'Quos autem asperiores sint.','2021-04-05 17:45:31','2021-06-05 19:17:25','Alice said to the three gardeners at it, and burning with curiosity, she ran off as hard as she spoke--fancy CURTSEYING as you\'re falling through the wood. \'If it had been. But her sister sat still.',NULL),(13,'Molestiae aspernatur cumque nostrum.','2021-09-06 09:03:52','2021-03-12 19:05:54','Alice in a coaxing tone, and added with a little door about fifteen inches high: she tried hard to whistle to it; but she thought it must be Mabel after all, and I had to stop and untwist it. After.',NULL),(16,'Odit quod et quia.','2022-01-10 21:16:42','2021-05-25 03:11:25','Why, I haven\'t been invited yet.\' \'You\'ll see me there,\' said the Dormouse; \'--well in.\' This answer so confused poor Alice, who felt very glad to do it?\' \'In my youth,\' said the White Rabbit.',NULL),(18,'Sed inventore dolor nobis.','2022-02-05 22:25:51','2021-10-12 07:55:55','',NULL),(24,'Recusandae unde aliquid.','2021-10-16 11:27:04','2021-04-29 06:36:45','Alice\'s first thought was that you had been looking at everything that Alice said; but was dreadfully puzzled by the Queen in a deep voice, \'are done with a sigh. \'I only took the place of the song,.',NULL),(26,'Velit qui recusandae quidem.','2021-05-15 05:30:49','2021-06-05 03:52:44','Turtle.\' These words were followed by a row of lodging houses, and behind them a new kind of serpent, that\'s all the rats and--oh dear!\' cried Alice hastily, afraid that it felt quite relieved to.',NULL),(27,'Minus iste cum.','2021-03-08 17:32:48','2021-04-24 21:04:40','',NULL),(29,'Quos optio neque.','2021-04-22 09:57:10','2021-10-02 18:04:19','',NULL),(30,'Praesentium velit at.','2021-04-13 15:19:56','2021-06-02 11:50:22','',NULL),(31,'Magni voluptatem sunt eius.','2021-08-06 10:16:28','2021-09-18 11:45:23','Alice led the way, and nothing seems to grin, How neatly spread his claws, And welcome little fishes in With gently smiling jaws!\' \'I\'m sure I\'m not particular as to prevent its undoing itself,) she.',NULL),(35,'Expedita voluptatem in et.','2021-12-07 22:59:45','2021-07-21 00:48:28','',NULL),(37,'Qui qui.','2022-01-04 01:27:47','2021-06-17 13:43:45','They were just beginning to get in?\' she repeated, aloud. \'I shall sit here,\' he said, \'on and off, for days and days.\' \'But what did the archbishop find?\' The Mouse did not like to go on with the.',NULL),(42,'Qui id ducimus labore.','2021-07-18 22:15:39','2021-12-06 01:00:02','Alice noticed, had powdered hair that WOULD always get into that lovely garden. First, however, she waited patiently. \'Once,\' said the Caterpillar. This was such a rule at processions; \'and besides,.',NULL),(44,'Soluta a accusantium iusto.','2021-08-14 01:48:44','2021-11-12 09:14:20','Alice\'s shoulder, and it was over at last: \'and I wish you wouldn\'t keep appearing and vanishing so suddenly: you make one repeat lessons!\' thought Alice; but she heard a little shaking among the.',NULL),(45,'Ut unde qui unde.','2021-12-25 18:12:26','2021-03-07 15:51:57','',NULL),(48,'Quidem alias.','2021-11-26 11:25:13','2021-11-16 05:22:11','They had not attended to this last remark that had made the whole court was in livery: otherwise, judging by his garden.\"\' Alice did not like the Queen?\' said the Cat. \'I don\'t think--\' \'Then you.',NULL),(49,'Similique accusantium.','2021-04-21 22:34:57','2021-07-13 19:41:37','Mock Turtle would be a queer thing, to be listening, so she began looking at everything that Alice quite jumped; but she stopped hastily, for the Duchess replied, in a low, trembling voice. \'There\'s.',NULL);
/*!40000 ALTER TABLE `KONCERTAS` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-03-02 12:56:15
