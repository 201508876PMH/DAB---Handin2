--
-- Create Table    : 'Person'   
-- personID        :  
-- adresseID       :  (references Adresse.adresseID)
-- firstName       :  
-- middleName      :  
-- lastName        :  
-- context         :  
-- gender          :  
--
CREATE TABLE Person (
    personID       INT NOT NULL,
    adresseID      BIGINT NOT NULL,
    firstName      NVARCHAR(15) NOT NULL,
    middleName     NVARCHAR(15) NOT NULL,
    lastName       NVARCHAR(15) NOT NULL,
    context        NVARCHAR(15) NOT NULL,
    gender         CHAR(15) NOT NULL,
CONSTRAINT pk_Person PRIMARY KEY CLUSTERED (personID),
CONSTRAINT fk_Person FOREIGN KEY (adresseID)
    REFERENCES Adresse (adresseID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)