CREATE OR REPLACE FUNCTION add_food_track_item(fatty_id INT, images text[], text text, date timestamp without time zone) 
RETURNS VOID AS $$
BEGIN
  INSERT INTO public.food_tracks (fatty_id, images, text, date)
  VALUES (fatty_id, images, text, date);
END;
$$ LANGUAGE plpgsql;