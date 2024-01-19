-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 29, 2022 at 09:56 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `darbas`
--

-- --------------------------------------------------------

--
-- Table structure for table `apmokejimas`
--

CREATE TABLE `apmokejimas` (
  `id` int(11) NOT NULL,
  `name` char(15) COLLATE utf8_lithuanian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `apmokejimas`
--

INSERT INTO `apmokejimas` (`id`, `name`) VALUES
(1, 'Bendru sutarimu'),
(2, 'Prieš darbą'),
(3, 'Po darbo'),
(4, 'Dalimis');

-- --------------------------------------------------------

--
-- Table structure for table `isiminta`
--

CREATE TABLE `isiminta` (
  `id` int(11) NOT NULL,
  `fk_Skelbimasid` int(11) NOT NULL,
  `fk_Vartotojasid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `isiminta`
--

INSERT INTO `isiminta` (`id`, `fk_Skelbimasid`, `fk_Vartotojasid`) VALUES
(17, 1, 4),
(29, 2, 16),
(30, 10, 16);

-- --------------------------------------------------------

--
-- Table structure for table `kategorija`
--

CREATE TABLE `kategorija` (
  `pavadinimas` varchar(255) COLLATE utf8_lithuanian_ci NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `kategorija`
--

INSERT INTO `kategorija` (`pavadinimas`, `id`) VALUES
('Žolės pjovimas', 1),
('Pagalbinis darbininkas', 2),
('Namų tvarkymas', 3),
('Namų remonto darbai', 4),
('Transporto remonto darbai', 5),
('Statybos', 6),
('Sezoninis darbas', 7),
('Kita', 8),
('test', 10);

-- --------------------------------------------------------

--
-- Table structure for table `komentaras`
--

CREATE TABLE `komentaras` (
  `komentaras` varchar(255) COLLATE utf8_lithuanian_ci NOT NULL,
  `id` int(11) NOT NULL,
  `fk_Vartotojasid` int(11) NOT NULL,
  `fk_Skelbimasid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `komentaras`
--

INSERT INTO `komentaras` (`komentaras`, `id`, `fk_Vartotojasid`, `fk_Skelbimasid`) VALUES
('Test', 9974, 16, 1),
('Test1', 9975, 16, 2),
('Test2', 9976, 16, 5),
('Test3', 9977, 16, 10),
('Test5', 9978, 16, 11),
('Test6', 9979, 4, 12),
('Test', 9980, 4, 13),
('Test8', 9981, 4, 16);

-- --------------------------------------------------------

--
-- Table structure for table `skelbimas`
--

CREATE TABLE `skelbimas` (
  `pavadinimas` varchar(255) COLLATE utf8_lithuanian_ci NOT NULL,
  `aprasymas` varchar(255) COLLATE utf8_lithuanian_ci NOT NULL,
  `uzmokestis` decimal(16,2) NOT NULL,
  `data` date NOT NULL DEFAULT current_timestamp(),
  `mokejimo_budas` int(11) NOT NULL,
  `id` int(11) NOT NULL,
  `fk_Vartotojasid` int(11) NOT NULL,
  `fk_Kategorijaid` int(11) NOT NULL,
  `adresas` varchar(255) COLLATE utf8_lithuanian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `skelbimas`
--

INSERT INTO `skelbimas` (`pavadinimas`, `aprasymas`, `uzmokestis`, `data`, `mokejimo_budas`, `id`, `fk_Vartotojasid`, `fk_Kategorijaid`, `adresas`) VALUES
('Sodo žolės pjovimas', 'Ieškau žmogaus, kuris nupjautų sode žolę. Pjovimo nedaug, apie 1 arą. Yra žoliapjovė, bet jei norit galit dirbti su sava technika.', '15.00', '2022-05-29', 3, 1, 7, 1, 'Kaunas, Studentų g. 50'),
('Pagalba trinkelių klojime', 'Kiemas yra klojamas trinkelėmis ir ieškomas pagalbinis darbininkas panešioti įrankius ar trinkeles. Darbo būtų apie savaitę laiko.', '250.00', '2022-05-29', 4, 2, 4, 2, 'Krekenava, Vytauto g. 6-1'),
('Garažo tvarkymas', 'Po mašinos remonto garažas yra nešvarus ir netvarkingas, tad ieškau žmogaus, kuris sutvarkytų garažą.', '44.99', '2022-05-29', 1, 5, 5, 3, 'Kaunas, Vydūno alėja 25'),
('Langų keitimas', 'Ieškau įmonės ar žmogaus, kurie apsiimtu darbu pakeisti senus medinių rėmų langus į naujus, plastikinius langus.', '80.00', '2022-05-29', 2, 10, 4, 4, 'Kaunas, Vydūno alėja 252'),
('Sugedo mašina', 'Sugedo mašina, nebeužsikuria. Ieškau žmogaus gebančio rasti ir sutaisyti problemą. Mašina: 2008 Ford Galaxy, 2.0l, 103kW.', '200.00', '2022-05-29', 3, 11, 4, 5, 'Kaunas, Vydūno alėja 252'),
('Žolės pjovėjo darbas visai vasarai', 'Vasarai išvykstu į užsienį ir ieškau žmogaus, kuris visą vasarą kieme pjautų žolę. Dėl kainos, manau, sutarsim. <i>INFORMACIJA TIK KOMENTARUOSE ARBA TELEFONU</i>', '1.00', '2022-05-29', 4, 12, 4, 1, 'Kaunas, Taikos prospektas 5'),
('Padangų keitėjas', 'Ateina sezonas keisti padangas, tad mūsų autoservisas ieško pagalbinio darbininko 1-2 savaitėm.', '500.00', '2022-05-29', 4, 13, 4, 2, 'Panevėžys, Beržų g. 0'),
('Braškių rinkėjas', 'Ieškau žmogaus norinčio rinkti ir tuo pačiu paskanauti šviežiom Lietuviškom braškėm. Užmokestis priklausys nuo pririnktų uogų kiekio. Taip pat siūlome nemokamą vežimą į darbą ir iš darbo Kauno rajone.', '20.60', '2022-05-29', 2, 16, 4, 7, 'Garliavos sodai'),
('Pavėsinės statybos', 'Ieškau žmonių, kurie gebėtų pastatyti medinę pavėsinę', '20.60', '2022-05-29', 3, 21, 4, 6, 'Jonava'),
('Egzaminų išlaikymas', 'Esu studentas ir nieko nesugebu, ieškau žmogaus, kas išlaikytų už mane egzaminus!', '999.99', '2022-05-29', 1, 22, 16, 8, 'Kaunas, Studentų g. 50');

-- --------------------------------------------------------

--
-- Table structure for table `vartotojas`
--

CREATE TABLE `vartotojas` (
  `vardas` varchar(255) COLLATE utf8_lithuanian_ci NOT NULL,
  `slaptazodis` varchar(255) COLLATE utf8_lithuanian_ci NOT NULL,
  `telefonas` varchar(255) COLLATE utf8_lithuanian_ci NOT NULL,
  `e_pastas` varchar(255) COLLATE utf8_lithuanian_ci NOT NULL,
  `miestas` varchar(255) COLLATE utf8_lithuanian_ci NOT NULL,
  `id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_lithuanian_ci;

--
-- Dumping data for table `vartotojas`
--

INSERT INTO `vartotojas` (`vardas`, `slaptazodis`, `telefonas`, `e_pastas`, `miestas`, `id`) VALUES
('Admin', '$2a$11$dReeS1hkl6CS/bb.4I9AKuOStDuL2i/sIHrJ69.Aff0qkzhwo0qNu', '8666666', 'admin@gmail.com', 'Kaunas', 4),
('Adminas', '$2a$11$J4pTtzNOt7WLmWQ8OGtqN.lQ3Be8cODTVUOdEeLFXjVVkDqijGKV.', '86666666', 'adminas@gmail.com', 'Kaunas', 5),
('test', '$2a$11$.x5ZIWrSsQZyHDxg.VOIK.QOv0FjGNbj8cYVQdDIws4qzRLKjQzXi', '86666', 'test@gmail.com', 'Kaunas', 6),
('testas', '$2a$11$6qjsXVprrN.Se54cQ64ZNOOQmVpEiDOWW2hl4EydMILvqHQzpDdEa', '86666', 'testas@gmail.com', 'Kaunas', 7),
('testass', '$2a$11$0FdVIzPmscFhfB6r/Wg3KeKjXgJTzSvih5B00AWjI3hlRBnV0b6GC', '86666', 'testass@gmail.com', 'Kaunas', 8),
('veikia', '$2a$11$WmnIaNz7V1Rxl2rVr0ka5u1Z67V4rK0sMCyjxO14s7aEoksM2QsIa', '8666', 'veikia@gmail.com', 'Kaunas', 9),
('pavyko', '$2a$11$BsHHphRDzcnmjPgAb14tCOh6LWzVjGb6ZBjHXfCJTB9cHq9o1U9/y', '866666', 'pavyko@gmail.com', 'Kaunas', 10),
('testasss', '$2a$11$D7TDOgZYT7BwKv333rUse.ifc6QQptzeHNpe0aqplaE2JjUw5.d5S', '8666', 'testasss@gmail.com', 'Kaunas', 11),
('testassss', '$2a$11$3ug/7VTdFPNLuqtCwWvbjuWzABNli2n7.Cm6bfqPsC.iwDBqohAue', '866', 'testassss@gmail.com', 'Kaunas', 12),
('testasssss', '$2a$11$.LUgvUeWMJ7qJ.nY14x6n.skAFxWmLbtMnwOYzywn6.PnBXSbBusS', '86666', 'testasssss@gmail.com', 'Kaunas', 13),
('testassssss', '$2a$11$5IZcX5bp/1UdSOJ1CCxV3usZFg1wJsyioXonvONFbVfxIXNDFKq/.', '8666', 'testassssss@gmail.com', 'Kaunas', 14),
('Bruh', '$2a$11$c739itT34v4weLlbXY8TieMMCWI/.K.2BjvHfwzriOEgtQnF1GZf6', '8666666', 'bruh@gmail.com', 'Kaunas', 15),
('Renatas', '$2a$11$Q2GoeM4vsFfA8poRjJOx3.5S8WdPMX8jABzumfBA2c4yE6ux0jSla', '860735208', 'renjoc@ktu.lt', 'Krekenava', 16);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `apmokejimas`
--
ALTER TABLE `apmokejimas`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `isiminta`
--
ALTER TABLE `isiminta`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Skelbimasid` (`fk_Skelbimasid`),
  ADD KEY `fk_Vartotojasid` (`fk_Vartotojasid`);

--
-- Indexes for table `kategorija`
--
ALTER TABLE `kategorija`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `komentaras`
--
ALTER TABLE `komentaras`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Vartotojasid` (`fk_Vartotojasid`),
  ADD KEY `fk_Skelbimasid` (`fk_Skelbimasid`);

--
-- Indexes for table `skelbimas`
--
ALTER TABLE `skelbimas`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_Vartotojasid` (`fk_Vartotojasid`) USING BTREE,
  ADD KEY `skelbimas_ibfk_1` (`mokejimo_budas`),
  ADD KEY `skelbimas_ibfk_3` (`fk_Kategorijaid`);

--
-- Indexes for table `vartotojas`
--
ALTER TABLE `vartotojas`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `apmokejimas`
--
ALTER TABLE `apmokejimas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `isiminta`
--
ALTER TABLE `isiminta`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- AUTO_INCREMENT for table `kategorija`
--
ALTER TABLE `kategorija`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `komentaras`
--
ALTER TABLE `komentaras`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9984;

--
-- AUTO_INCREMENT for table `skelbimas`
--
ALTER TABLE `skelbimas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT for table `vartotojas`
--
ALTER TABLE `vartotojas`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `isiminta`
--
ALTER TABLE `isiminta`
  ADD CONSTRAINT `isiminta_ibfk_1` FOREIGN KEY (`fk_Skelbimasid`) REFERENCES `skelbimas` (`id`),
  ADD CONSTRAINT `isiminta_ibfk_2` FOREIGN KEY (`fk_Vartotojasid`) REFERENCES `vartotojas` (`id`);

--
-- Constraints for table `komentaras`
--
ALTER TABLE `komentaras`
  ADD CONSTRAINT `komentaras_ibfk_1` FOREIGN KEY (`fk_Vartotojasid`) REFERENCES `vartotojas` (`id`),
  ADD CONSTRAINT `komentaras_ibfk_2` FOREIGN KEY (`fk_Skelbimasid`) REFERENCES `skelbimas` (`id`);

--
-- Constraints for table `skelbimas`
--
ALTER TABLE `skelbimas`
  ADD CONSTRAINT `skelbimas_ibfk_1` FOREIGN KEY (`mokejimo_budas`) REFERENCES `apmokejimas` (`id`),
  ADD CONSTRAINT `skelbimas_ibfk_2` FOREIGN KEY (`fk_Vartotojasid`) REFERENCES `vartotojas` (`id`),
  ADD CONSTRAINT `skelbimas_ibfk_3` FOREIGN KEY (`fk_Kategorijaid`) REFERENCES `kategorija` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
