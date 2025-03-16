CREATE TABLE public.users (
    id uuid DEFAULT gen_random_uuid() NOT NULL,
    username varchar NOT NULL,
    "password" varchar NOT NULL,
    email varchar NOT NULL,
    CONSTRAINT users_pk PRIMARY KEY (id),
    CONSTRAINT users_unique UNIQUE (username)
);

CREATE UNIQUE INDEX users_username_idx ON public.users (username);
