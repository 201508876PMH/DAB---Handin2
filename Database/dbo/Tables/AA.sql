--
-- Create Table    : 'AA'   
-- AAID            :  (references Adresse.adresseID)
-- personID        :  (references Person.personID)
--
CREATE TABLE AA (
    AAID           BIGINT NOT NULL,
    personID       INT NOT NULL,
CONSTRAINT pk_AA PRIMARY KEY CLUSTERED (AAID,personID),
CONSTRAINT fk_AA FOREIGN KEY (AAID)
    REFERENCES Adresse (adresseID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_AA2 FOREIGN KEY (personID)
    REFERENCES Person (personID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)