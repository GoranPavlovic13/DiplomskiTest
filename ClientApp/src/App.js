import { ApolloProvider } from "@apollo/client";
import "./App.css";
import Client from "./Graphql/graphqlService/Client";
import Header from "./components/Layout/Header";
import ProgrammingLanguages from "./components/ProgrammingLanguages/ProgrammingLanguages";  
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Lectures from "./components/Lectures/Lectures";
import Test from "./components/Test/Test";
import AllLectures from "./components/Lectures/AllLectures";
import UpdateLecture from "./components/Lectures/UpdateLecture";
import UpdateProgrammingLanguage from "./components/ProgrammingLanguages/UpdateProgrammingLanguage";

function App() {
  return (
    <ApolloProvider client={Client}>
      <Router>
        <Header></Header>
        <main>
          <Routes>
            <Route path="/" element={<ProgrammingLanguages />} />
            <Route path="/programming-languages/:id/lectures" element={<Lectures></Lectures>} />
            <Route path="/test/:testId" element={<Test />} />
            <Route path="/lectures" element={<AllLectures />} />
            <Route path="/edit-lecture/:id" element={<UpdateLecture />} />
            <Route path="/programming-languages/:id/edit" element={<UpdateProgrammingLanguage />} />
          </Routes>
        </main>
      </Router>
    </ApolloProvider>
  );
}

export default App;
