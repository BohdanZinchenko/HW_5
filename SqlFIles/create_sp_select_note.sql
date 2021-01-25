create or replace FUNCTION select_note(note_id uuid ) returns TABLE(NoteId uuid, Head character varying, TextBody character varying, is_deleted boolean, User_Id integer, Last_time_modified timestamp with time zone, Name character varying, Last_Name character varying)    language sql
    as $$
    select n.id,n.header,n.body,n.is_deleted,n.user_id,n.modified_at,u.first_name,u.last_name from notes n  inner join users u on u.id = n.user_id
    where n.id = note_id

    $$;
