CREATE FUNCTION insert_notes(note_id uuid  , note_header CHARACTER varying (128) , note_body character varying(1024), note_user_id int)  returns  void

AS $$
    INSERT INTO notes (id , header , body , user_id) VALUES (note_id,note_header,note_body,  note_user_id);
$$

LANGUAGE sql