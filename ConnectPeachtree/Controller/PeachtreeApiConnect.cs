using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sage.Peachtree.API;

namespace ConnectPeachtree.Controller
{
    class PeachtreeApiConnect
    {

        public void fun()
        {
            // the main session into the Sage 50 application 
            PeachtreeSession apiSession = new PeachtreeSession();
            // the active Sage 50 Company 
            Company companyContext = null;

            // start the session. 
            // with no application ID, you can only open Sample companies 
            apiSession.Begin("SNT");

            // Get CompanyIdentifer for Bellwether Garden Supply sample company 
            CompanyIdentifierList m_companyIdList = apiSession.CompanyList();
            CompanyIdentifier companyId = m_companyIdList.Find(

                delegate(CompanyIdentifier o)
                { return o.CompanyName == "Bellwether Garden Supply"; }
                );

            // Ask the Sage 50 application if this application has 
            // been granted access to the company.
            AuthorizationResult AuthResult = apiSession.VerifyAccess(companyId);
            // check if the app has authorization before 
            if (AuthResult == AuthorizationResult.Granted)
            {
                // open the company 
                companyContext = apiSession.Open(companyId);
            }
        }
    }
}
