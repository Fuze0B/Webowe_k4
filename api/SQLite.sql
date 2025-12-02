CREATE TABLE movies(
    id INTEGER PRIMARY KEY,
    title TEXT NOT NULL,
    director TEXT NOT NULL,
    year INTEGER
);

INSERT INTO movies (title, director, year) VALUES
('Inception', 'Christopher Nolan', 2010),
('The Matrix', 'The Wachowskis', 1999),
('Interstellar', 'Christopher Nolan', 2014);

INSERT INTO movies (title, director, year) VALUES
('The Godfather', 'Francis Ford Coppola', 1972),
('Pulp Fiction', 'Quentin Tarantino', 1994),
('Blade Runner', 'Ridley Scott', 1982),
('The Dark Knight', 'Christopher Nolan', 2008),
('Forrest Gump', 'Robert Zemeckis', 1994),
('The Lord of the Rings: The Fellowship of the Ring', 'Peter Jackson', 2001),
('The Shining', 'Stanley Kubrick', 1980),
('Mad Max: Fury Road', 'George Miller', 2015),
('Fight Club', 'David Fincher', 1999),
('The Prestige', 'Christopher Nolan', 2006);
