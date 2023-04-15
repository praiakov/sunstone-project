
\c sunstonedb

CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE "Gemstones"
(
 "Id" uuid DEFAULT uuid_generate_v4 (),
 "Name" VARCHAR (30) NOT NULL,
 "Carat" decimal NOT NULL,
 "Clarity" decimal NOT NULL,
 "Color" integer NOT NULL,
 "Created" date NOT NULL
);

