--
-- Create Table    : 'Adresse'   
-- adresseID       :  
-- vejNavn         :  
-- townID          :  (references Town.townID)
-- vejNummer       :  
--
CREATE TABLE Adresse (
    adresseID      BIGINT IDENTITY(1,1) NOT NULL,
    vejNavn        NVARCHAR(15) NOT NULL,
    townID         INT NOT NULL,
    vejNummer      NVARCHAR(1000) NOT NULL,
CONSTRAINT pk_Adresse PRIMARY KEY CLUSTERED (adresseID),
CONSTRAINT fk_Adresse FOREIGN KEY (townID)
    REFERENCES Town (townID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)