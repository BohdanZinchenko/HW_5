Create or replace function select_user_notes (user_id_find int) returns  notes
language sql
As $$
    select * from notes n
    where n.user_id = user_id_find and n.is_deleted = false
    $$;