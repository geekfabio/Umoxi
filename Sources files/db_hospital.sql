-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 13, 2022 at 03:33 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 7.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_hospital`
--

-- --------------------------------------------------------

--
-- Table structure for table `banco_sangue_estado`
--

CREATE TABLE `banco_sangue_estado` (
  `id` int(11) NOT NULL,
  `sangue_grupo` varchar(3) DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `data_criado` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `banco_sangue_estado`
--

INSERT INTO `banco_sangue_estado` (`id`, `sangue_grupo`, `status`, `data_criado`) VALUES
(1, 'A+', '0', '2022-03-01 10:40:07'),
(2, 'B+', '0', '2022-03-01 11:10:55'),
(3, 'A-', '0', '2022-03-01 11:11:24'),
(4, 'B-', '0', '2022-03-01 11:11:44'),
(5, 'O+', '0', '2022-03-01 11:12:06'),
(6, 'O-', '0', '2022-03-01 11:12:20'),
(7, 'AB+', '0', '2022-03-01 11:12:36'),
(8, 'AB-', '0', '2022-03-01 11:13:18');

-- --------------------------------------------------------

--
-- Table structure for table `hospital`
--

CREATE TABLE `hospital` (
  `hospital_id` int(11) NOT NULL,
  `nome` varchar(100) NOT NULL,
  `endereco` varchar(100) NOT NULL,
  `email` varchar(80) NOT NULL,
  `contactos` varchar(30) NOT NULL,
  `nif` varchar(20) NOT NULL,
  `logo` varchar(255) NOT NULL,
  `data_cadastro` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `usuarios`
--

CREATE TABLE `usuarios` (
  `usuario_id` int(11) NOT NULL,
  `usuario` varchar(50) NOT NULL,
  `nome` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(100) NOT NULL,
  `ativo` varchar(1) NOT NULL DEFAULT 'Y',
  `data_cadastro` date NOT NULL,
  `foto` varchar(255) NOT NULL DEFAULT 'sem_foto',
  `funcao` varchar(12) NOT NULL DEFAULT 'medico',
  `contacto` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `usuarios`
--

INSERT INTO `usuarios` (`usuario_id`, `usuario`, `nome`, `password`, `email`, `ativo`, `data_cadastro`, `foto`, `funcao`, `contacto`) VALUES
(1, 'a', 'admin', 'a', 'a', 'Y', '2022-03-13', 'sem_foto', 'admin', '929725366');

-- --------------------------------------------------------

--
-- Table structure for table `usuario_log`
--

CREATE TABLE `usuario_log` (
  `log_id` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `action` int(255) NOT NULL,
  `date` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `hospital`
--
ALTER TABLE `hospital`
  ADD PRIMARY KEY (`hospital_id`);

--
-- Indexes for table `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`usuario_id`);

--
-- Indexes for table `usuario_log`
--
ALTER TABLE `usuario_log`
  ADD PRIMARY KEY (`log_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `hospital`
--
ALTER TABLE `hospital`
  MODIFY `hospital_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `usuario_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `usuario_log`
--
ALTER TABLE `usuario_log`
  MODIFY `log_id` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
