create TABLE notes
(
        id uuid primary key ,
        header character varying(128) not null ,
        body character varying(1024) not null ,
        is_deleted boolean not null default false,
        user_id integer references users (id) not null ,
        modified_at  timestamptz not null default current_timestamp
);

CREATE INDEX ON notes (modified_at)

