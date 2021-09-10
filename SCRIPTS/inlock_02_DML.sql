USE INLOCK_GAMES_MANHA;
GO

INSERT INTO TIPOUSUARIO (tituloTipoUsuario)
VALUES ('Administrador'), ('Cliente');
GO

INSERT INTO ESTUDIO (nomeEstudio)
VALUES ('Rockstar Studios'), ('Square Enix'), ('Blizzard');
GO

INSERT INTO USUARIO (idTipoUsuario, email, senha)
VALUES (1, 'admin@admin.com', 'admin'), (2, 'cliente@cliente.com', 'cliente');
GO

INSERT INTO JOGOS (idEstudio, nomeJogo, descricao, dataLancamento, valor)
VALUES 
(3, 'Diablo 3', 'é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', '2012-05-12', 99.00), 
(1, 'Red Dead Redemption II', 'jogo eletrônico de ação-aventura western.', '2018-10-26', 120.00);