import { useEffect, useState } from "react";
import $api from "./http";
import { User } from "./models";
import RemoveUserButton from "./components/RemoveUserButton";
import AddUserButton from "./components/AddUserButton";
import TodosComponent from "./components/TodosComponent";

function App() {
  const [userData, setUserData] = useState<User[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await $api.get<User[]>("/api/user-todo");

        setUserData(response.data);
      } catch (err) {
        console.error("User fetch data error ", err);
      }
    };

    fetchData();
  }, []);

  return (
    <div className="container flex flex-col justify-center items-center space-y-5 max-w-7xl mx-auto h-auto mt-16">
      {userData.length !== 0 ? (
        userData.map((user: User) => (
          <div key={user.id} className="flex w-full space-x-8">
            <div className="collapse collapse-arrow bg-base-200">
              <input type="radio" name="my-accordion-2" />
              <div className="collapse-title text-xl font-medium flex justify-between">
                <span className="badge badge-primary text-lg font-medium">
                  {user.nickname}
                </span>
              </div>
              <div className="collapse-content">
                <TodosComponent user={user} />
              </div>
            </div>
            <RemoveUserButton
              userData={userData}
              setUserData={setUserData}
              userId={user.id}
            />
          </div>
        ))
      ) : (
        <div className="flex w-full justify-center items-center">
          <span className="loading loading-spinner loading-lg"></span>
        </div>
      )}

      <AddUserButton userData={userData} setUserData={setUserData} />
    </div>
  );
}

export default App;
