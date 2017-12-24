CREATE OR REPLACE FUNCTION get_fatty_by_id(
  fatty_id int
) 
RETURNS TABLE
(
  id integer,
  name text,
  surname text,
  password text,
  email text,
  birthday timestamp without time zone,
  sex smallint,
  hidefoodtrach boolean,
  hideage boolean,
  hideemail boolean,
  currentweight double precision,
  desiredweight double precision,
  heigth double precision,
  trainer_id integer
)
 AS $$
BEGIN
  RETURN QUERY SELECT
    f.id,
    f.name,
    f.surname,
    f.password,
    f.email,
    f.birthday,
    f.sex,
    f.hidefoodtrach,
    f.hideage,
    f.hideemail,
    f.currentweight,
    f.desiredweight,
    f.heigth,
    f.trainer_id
  FROM public.fattyes f
  WHERE f.id = fatty_id;
END;
$$ LANGUAGE plpgsql;