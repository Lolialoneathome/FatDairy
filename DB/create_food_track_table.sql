CREATE TABLE food_tracks (
  fatty_id integer NOT NULL,
  images text[],
  text text,
  date timestamp without time zone NOT NULL,
  CONSTRAINT fatty_id_fk FOREIGN KEY (fatty_id) REFERENCES fattyes (id)
)