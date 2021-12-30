INSERT INTO `person` (`id`, `address`, `first_name`, `gender`, `last_name`) VALUES
	(1, 'São Paulo - Brasil', 'Ayrton', 'Male', 'Senna'),
	(2, 'Anchiano - Italy', 'Leonardo', 'Male', 'da Vinci'),
	(3, 'Porbandar - India', 'Mahatma', 'Male', 'Gandhi'),
	(4, 'Kentucky - USA', 'Mohamed Ali', 'Male', 'Gandhi'),
	(5, 'Mvezo - South Africa', 'Nelson', 'Male', 'Mandela');

/*migration com erro, o modelo abaixo é inserido no banco:
  INSERT INTO `rest_with_asp_net_udemy`.`Person` (`id`, `first_name`, `last_name`, `adress`, `gender`) 
VALUES ('1', 'teste', 'teste', 'ali', 'm');    */