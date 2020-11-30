# Host: localhost  (Version 5.5.5-10.4.11-MariaDB)
# Date: 2020-11-30 16:41:30
# Generator: MySQL-Front 6.0  (Build 2.20)


#
# Structure for table "completa"
#

DROP TABLE IF EXISTS `completa`;
CREATE TABLE `completa` (
  `nNF` int(50) NOT NULL,
  `Dest_CNPJ` int(20) DEFAULT NULL,
  `Dest_xNome` varchar(70) DEFAULT NULL,
  `Dest_xLgr` varchar(70) DEFAULT NULL,
  `Dest_xBairro` varchar(70) DEFAULT NULL,
  `Dest_xMun` varchar(70) DEFAULT NULL,
  `Dest_UF` varchar(2) DEFAULT NULL,
  `Dest_CEP` varchar(20) DEFAULT NULL,
  `Dest_fone` varchar(15) DEFAULT NULL,
  `Dest_IE` int(20) DEFAULT NULL,
  `dEmit` date DEFAULT '2003-05-08',
  `dRecbto` date DEFAULT '2003-05-09',
  `hRecbto` time DEFAULT NULL,
  `CNPJ` int(20) DEFAULT NULL,
  `Emit_xNome` varchar(70) DEFAULT NULL,
  `Emit_xLgr` varchar(70) DEFAULT NULL,
  `Emit_xBairro` varchar(70) DEFAULT NULL,
  `Emit_xMun` varchar(70) DEFAULT NULL,
  `Emit_UF` varchar(2) DEFAULT NULL,
  `Emit_CEP` varchar(20) DEFAULT NULL,
  `Emit_fone` varchar(15) DEFAULT NULL,
  `Emit_IE` int(20) DEFAULT NULL,
  `Emit_nro` int(10) DEFAULT NULL,
  `vBc` decimal(9,0) DEFAULT NULL,
  `vICMS` decimal(9,0) DEFAULT NULL,
  `vBCTS` decimal(9,0) DEFAULT NULL,
  `vProd` decimal(9,0) DEFAULT NULL,
  `vFrete` decimal(9,0) DEFAULT NULL,
  `vSeg` decimal(9,0) DEFAULT NULL,
  `vDesc` decimal(9,0) DEFAULT NULL,
  `vIPI` decimal(9,0) DEFAULT NULL,
  `vOutro` decimal(9,0) DEFAULT NULL,
  `vNF` decimal(9,0) DEFAULT NULL,
  `Transp_CNPJ` int(20) DEFAULT NULL,
  `Transp_xNome` varchar(70) DEFAULT NULL,
  `Transp_xLgr` varchar(70) DEFAULT NULL,
  `Transp_xMun` varchar(70) DEFAULT NULL,
  `Transp_UF` varchar(2) DEFAULT NULL,
  `Transp_IE` int(20) DEFAULT NULL,
  `qVol` int(10) DEFAULT NULL,
  `esp` varchar(40) DEFAULT NULL,
  `funId` int(50) DEFAULT NULL,
  PRIMARY KEY (`nNF`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "completa"
#

INSERT INTO `completa` VALUES (648556,2147483647,'TECHNOSERVICE BRASIL MONTAGENS LTDA','AV. PIERRE SIMON DE LAPLACE','TECHNO PARK','CAMPINAS','SP','13069320','1937839730',2147483647,'0000-00-00','0000-00-00','12:26:00',2147483647,'SAMSUNG ELETRONICA DA AMAZONIA LTDA','Av. Thomas Nilsen Junior','Parque Imperador','Campinas','SP','13097105','1945012000',2147483647,150,0,0,0,26294,0,0,0,0,0,26294,2147483647,'MOTO HELP ENTREGAS RAPIDAS LTDA EPP','RUA SERRA AZUL 277','CAMPINAS','SP',2147483647,6070,'Peca',1),(648577,2147483647,'TECHNOSERVICE BRASIL MONTAGENS LTDA','AV. PIERRE SIMON DE LAPLACE','TECHNO PARK','CAMPINAS','SP','13069320','1937839730',0,'2001-01-01','2001-01-01','14:30:00',2147483647,'SAMSUNG ELETRONICA DA AMAZONIA LTDA','Av. Thomas Nilsen Junior','Parque Imperador','Campinas','SP','13097105','1945012000',0,150,0,0,0,14101,0,0,0,0,0,14101,2147483647,'MOTO HELP ENTREGAS RAPIDAS LTDA EPP','RUA SERRA AZUL 277','CAMPINAS','SP',2147483647,1120,'Peca',1);

#
# Structure for table "destinatario"
#

DROP TABLE IF EXISTS `destinatario`;
CREATE TABLE `destinatario` (
  `nNF` int(50) NOT NULL,
  `CNPJ` int(20) DEFAULT NULL,
  `xNome` varchar(70) DEFAULT NULL,
  `xLgr` varchar(70) DEFAULT NULL,
  `xBairro` varchar(80) DEFAULT NULL,
  `xMun` varchar(30) DEFAULT NULL,
  `UF` varchar(2) DEFAULT NULL,
  `CEP` varchar(20) DEFAULT NULL,
  `fone` varchar(15) DEFAULT NULL,
  `IE` int(20) DEFAULT NULL,
  `dEmit` date DEFAULT NULL,
  `dRecbto` date DEFAULT NULL,
  `hRecbto` time DEFAULT NULL,
  PRIMARY KEY (`nNF`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "destinatario"
#

INSERT INTO `destinatario` VALUES (648556,2147483647,'TECHNOSERVICE BRASIL MONTAGENS LTDA','AV. PIERRE SIMON DE LAPLACE','TECHNO PARK','CAMPINAS','SP','13069320','1937839730',2147483647,'0000-00-00','0000-00-00','12:26:00'),(648577,2147483647,'TECHNOSERVICE BRASIL MONTAGENS LTDA','AV. PIERRE SIMON DE LAPLACE','TECHNO PARK','CAMPINAS','SP','13069320','1937839730',0,'2001-01-01','2001-01-01','14:30:00');

#
# Structure for table "emitente"
#

DROP TABLE IF EXISTS `emitente`;
CREATE TABLE `emitente` (
  `nNF` int(50) NOT NULL,
  `dhEmi` date DEFAULT NULL,
  `CNPJ` varchar(40) DEFAULT NULL,
  `xNome` varchar(80) DEFAULT NULL,
  `xLgr` varchar(80) DEFAULT NULL,
  `nro` int(3) DEFAULT NULL,
  `xBairro` varchar(80) DEFAULT NULL,
  `xMun` varchar(80) DEFAULT NULL,
  `UF` varchar(2) DEFAULT NULL,
  `CEP` varchar(20) DEFAULT NULL,
  `fone` int(13) DEFAULT NULL,
  `IE` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`nNF`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "emitente"
#

INSERT INTO `emitente` VALUES (648556,'0000-00-00','00280273000218','SAMSUNG ELETRONICA DA AMAZONIA LTDA','Av. Thomas Nilsen Junior',150,'Parque Imperador','Campinas','SP','13097105',1945012000,'244956031110'),(648577,'2001-01-01','2147483647','SAMSUNG ELETRONICA DA AMAZONIA LTDA','Av. Thomas Nilsen Junior',150,'Parque Imperador','Campinas','SP','13097105',1945012000,'');

#
# Structure for table "funcionario"
#

DROP TABLE IF EXISTS `funcionario`;
CREATE TABLE `funcionario` (
  `cod_fun` int(10) NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) NOT NULL,
  `cargo` varchar(80) NOT NULL,
  `senha` varchar(16) NOT NULL,
  `CPF` varchar(11) NOT NULL,
  `email` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`cod_fun`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

#
# Data for table "funcionario"
#

INSERT INTO `funcionario` VALUES (1,'Rodrigo','Gerente','1234','55544443332','rodrigo@gmail.com'),(2,'Bruno','Estagiário','123','50071186565','brunos@email.com');

#
# Structure for table "imposto"
#

DROP TABLE IF EXISTS `imposto`;
CREATE TABLE `imposto` (
  `nNF` int(50) NOT NULL,
  `vBC` decimal(9,0) DEFAULT NULL,
  `vICMS` decimal(9,0) DEFAULT NULL,
  `vBCST` decimal(9,0) DEFAULT NULL,
  `vProd` decimal(9,0) DEFAULT NULL,
  `vFrete` decimal(9,0) DEFAULT NULL,
  `vSeg` decimal(9,0) DEFAULT NULL,
  `vDesc` decimal(9,0) DEFAULT NULL,
  `vIPI` decimal(9,0) DEFAULT NULL,
  `vOutro` decimal(9,0) DEFAULT NULL,
  `vNF` decimal(9,0) DEFAULT NULL,
  PRIMARY KEY (`nNF`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "imposto"
#

INSERT INTO `imposto` VALUES (648556,0,0,0,26294,0,0,0,0,0,26294),(648577,0,0,0,14101,0,0,0,0,0,14101);

#
# Structure for table "produtos"
#

DROP TABLE IF EXISTS `produtos`;
CREATE TABLE `produtos` (
  `cProd` varchar(40) NOT NULL,
  `nNF` int(50) DEFAULT NULL,
  `xProd` varchar(100) DEFAULT NULL,
  `NCM` int(20) DEFAULT NULL,
  `CFOP` int(20) DEFAULT NULL,
  `uCom` varchar(2) DEFAULT NULL,
  `qCom` decimal(10,0) DEFAULT NULL,
  `vUnCom` decimal(10,0) DEFAULT NULL,
  `vProd` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`cProd`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "produtos"
#

INSERT INTO `produtos` VALUES ('648577',648577,'648577',0,85076000,'59',0,1120,13),('GH39-02002A',648556,'CONDUTOR ELTRICO PARA TENSO INFERIOR A - EAN:',85444200,1200700,'59',0,400,3),('GH39-02060A',648556,'CONDUTOR(ES) ISOLADO(S) PARA USOS ELETRI - EAN:',85444200,1200700,'59',0,350,4),('GH44-02960A',648556,'CARREGADOR DE BATERIA PARA TELEFONE CELU - EAN:',85044021,1200100,'59',0,450,14),('GH44-03059A',648556,'CARREGADOR DE BATERIA PARA TELEFONE CELU - EAN:',85044021,1200100,'59',0,200,20),('GH59-15063A',648556,'FONE DE OUVIDO COMBINADO COM MICROFONE. - EAN:',85183000,2105700,'59',0,600,4),('GH59-15252A',648556,'FONE DE OUVIDO COMBINADO COM MICROFONE. - EAN:',85183000,2105700,'59',0,320,28),('GH69-36379A',648556,'DIVISORIA DE PAPEL EM FORMA PROPRIA. - EAN:',48239099,NULL,'59',0,500,2),('GH69-36977A',648556,'CAIXA DE PAPELAO NAO ONDULADO. - EAN:',48192000,NULL,'59',0,1050,0),('GH69-36979A',648556,'DIVISORIA DE PAPEL EM FORMA PROPRIA. - EAN:',48239099,NULL,'59',0,600,0),('GH69-36981A',648556,'DIVISORIA DE PAPEL EM FORMA PROPRIA. - EAN:',48239099,NULL,'59',0,400,0),('GH69-36983A',648556,'CAIXA DE PAPELAO NAO ONDULADO. - EAN:',48192000,NULL,'59',0,1200,0);

#
# Structure for table "transportador"
#

DROP TABLE IF EXISTS `transportador`;
CREATE TABLE `transportador` (
  `nNF` int(50) NOT NULL,
  `CNPJ` int(20) DEFAULT NULL,
  `xNome` varchar(100) DEFAULT NULL,
  `IE` int(20) DEFAULT NULL,
  `xEnder` varchar(60) DEFAULT NULL,
  `xMun` varchar(40) DEFAULT NULL,
  `UF` varchar(2) DEFAULT NULL,
  `qVol` int(10) DEFAULT NULL,
  `esp` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`nNF`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

#
# Data for table "transportador"
#

INSERT INTO `transportador` VALUES (648556,2147483647,'MOTO HELP ENTREGAS RAPIDAS LTDA EPP',2147483647,'RUA SERRA AZUL 277','CAMPINAS','SP',6070,'Peca'),(648577,2147483647,'MOTO HELP ENTREGAS RAPIDAS LTDA EPP',2147483647,'RUA SERRA AZUL 277','CAMPINAS','SP',1120,'Peca');
