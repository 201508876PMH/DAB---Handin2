--
-- Create Table    : 'Town'   
-- townID          :  
-- postNummer      :  
-- townNavn        :  
--
CREATE TABLE Town (
    townID         INT NOT NULL,
    postNummer     NVARCHAR(4) NOT NULL,
    townNavn       NVARCHAR(15) NOT NULL,
CONSTRAINT pk_Town PRIMARY KEY CLUSTERED (townID))