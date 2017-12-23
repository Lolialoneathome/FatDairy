CREATE OR REPLACE FUNCTION add_fatty(
  name text,
  surname text,
  password text,
  email text,
  birthday timestamp without time zone,
  sex smallint,
  hidefoodtrach boolean,
  hideage boolean,
  hideemail boolean,
  currentweight decimal,
  desiredweight decimal,
  heigth decimal,
  trainer_id integer
) 
RETURNS INTEGER AS $$
BEGIN
  INSERT INTO public.fattyes(
    name,
    surname,
    password,
    email,
    birthday,
    sex,
    hidefoodtrach,
    hideage,
    hideemail,
    currentweight,
    desiredweight,
    heigth,
    trainer_id)
  VALUES(
    name,
    surname,
    password,
    email,
    birthday,
    sex,
    hidefoodtrach,
    hideage,
    hideemail,
    currentweight,
    desiredweight,
    heigth,
    trainer_id) RETURNING id;
	
END;
$$ LANGUAGE plpgsql;