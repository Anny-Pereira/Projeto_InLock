USE INLOCK_GAMES_MANHA;
GO

--Listar todos os Usuários
SELECT email, senha, tituloTipoUsuario FROM USUARIO LEFT JOIN TIPOUSUARIO ON TIPOUSUARIO.idTipoUsuario = USUARIO.idTipoUsuario;

--Listar todos os Estúdios 
SELECT * FROM ESTUDIO;

--Listar todos os jogos
SELECT nomeEstudio, nomeJogo, descricao, dataLancamento, valor FROM JOGOS LEFT JOIN ESTUDIO ON ESTUDIO.idEstudio = JOGOS.idEstudio;

--Listar todos os jogos e suas respectivos estúdios
SELECT nomeJogo, nomeEstudio FROM JOGOS LEFT JOIN ESTUDIO ON JOGOS.idEstudio = ESTUDIO.idEstudio;

--Listar todos os estúdios com os respectivos jogos (mesmo que eles não tenham jogos cadastrados)
SELECT nomeEstudio, nomeJogo FROM ESTUDIO LEFT JOIN JOGOS ON ESTUDIO.idEstudio = JOGOS.idEstudio;

--Buscar um usuário por email e senha (login)
SELECT email, senha FROM USUARIO WHERE email = 'cliente@cliente.com' AND senha = 'cliente';

--Buscar um jogo por idJogo
SELECT nomeJogo, descricao, dataLancamento, valor FROM JOGOS WHERE idJogo = 2;

--Buscar um estúdio por idEstudio
SELECT nomeEstudio FROM ESTUDIO WHERE idEstudio = 1;