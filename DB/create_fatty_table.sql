CREATE TABLE fattyes (
  id serial NOT NULL,
  name text NOT NULL,
  surname text NOT NULL,
  password text NOT NULL,
  email text NOT NULL,
  birthday timestamp without time zone,
  sex smallint,
  hidefoodtrach boolean default false,
  hideage boolean default false,
  hideemail boolean default false,
  currentweight double precision,
  desiredweight double precision,
  heigth double precision NOT NULL,
  trainer_id integer,
  CONSTRAINT fatty_id_pk PRIMARY KEY (id),
  CONSTRAINT constraint_email UNIQUE (email)
)