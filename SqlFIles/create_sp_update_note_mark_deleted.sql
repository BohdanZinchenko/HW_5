Create or replace Function update_mark(mark_id uuid) returns void
    language sql
As
    $$
    update notes n set is_deleted = true,
     modified_at = current_timestamp where n.id = mark_id

    $$