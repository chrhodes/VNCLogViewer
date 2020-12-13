using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using VNC;
using VNC.Core.DomainServices;

using VNCLogViewer.Domain;
using VNCLogViewer.Persistence.Data;

namespace VNCLogViewer.DomainServices
{
    // NOTE(crhodes)
    // This creates a new context each time.  How would HasChanges work?

    public class LiveLogViewerVNCDataService : ILiveLogViewerVNCDataService
    {
        private Func<VNCLogViewerDbContext> _contextCreator;

        private ConnectedRepository<LiveLogViewerVNC> _repository;

        #region Constructors

        public LiveLogViewerVNCDataService(Func<VNCLogViewerDbContext> context)
        {
            Int64 startTicks = Log.CONSTRUCTOR("Enter", Common.LOG_APPNAME);

            _contextCreator = context;

            Log.CONSTRUCTOR("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Constructors

        #region Public Methods

        #region All

        public IEnumerable<LiveLogViewerVNC> All()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                return _repository.All();
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task<List<LiveLogViewerVNC>> AllAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                return await _repository.AllAsync();
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<LiveLogViewerVNC> AllInclude(
            params Expression<Func<LiveLogViewerVNC, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                return _repository.AllInclude(includeProperties);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<LiveLogViewerVNC>> AllIncludeAsync(
            params Expression<Func<LiveLogViewerVNC, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                return await _repository.AllIncludeAsync(includeProperties);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion All

        #region Find

        public LiveLogViewerVNC FindById(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                return _repository.FindById(entityId);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task<LiveLogViewerVNC> FindByIdAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                return await _repository.FindByIdAsync(entityId);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<LiveLogViewerVNC> FindBy(
            Expression<Func<LiveLogViewerVNC, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                return _repository.FindBy(predicate);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<LiveLogViewerVNC>> FindByAsync(
            Expression<Func<LiveLogViewerVNC, bool>> predicate)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                return await _repository.FindByAsync(predicate);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public IEnumerable<LiveLogViewerVNC> FindByInclude(
            Expression<Func<LiveLogViewerVNC, bool>> predicate,
            params Expression<Func<LiveLogViewerVNC, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                return _repository.FindByInclude(predicate, includeProperties);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task<IEnumerable<LiveLogViewerVNC>> FindByIncludeAsync(
            Expression<Func<LiveLogViewerVNC, bool>> predicate,
            params Expression<Func<LiveLogViewerVNC, object>>[] includeProperties)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                return await _repository.FindByIncludeAsync(predicate, includeProperties);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        // TODO(crhodes)
        // Decide if we need FindByKey

        #endregion Find

        #region Insert

        public void Insert(LiveLogViewerVNC entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                _repository.Insert(entity);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task InsertAsync(LiveLogViewerVNC entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                await _repository.InsertAsync(entity);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Insert

        #region Update

        public void Update(LiveLogViewerVNC entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                _repository.Update(entity);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                await _repository.UpdateAsync();
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task UpdateAsync(LiveLogViewerVNC entity)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);

                if (entity.Id <= 0)
                {
                    await _repository.InsertAsync(entity);
                }
                else
                {
                    await _repository.UpdateAsync(entity);
                }
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion Update

        #region Delete

        public void Delete(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                _repository.Delete(entityId);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task DeleteAsync(int entityId)
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                await _repository.DeleteAsync(entityId);
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);
        }

        public bool HasChanges()
        {
            Int64 startTicks = Log.DOMAINSERVICES("Enter", Common.LOG_APPNAME);

            // TODO(crhodes)
            // Hum.  How to determine if something has changed that can drive the UI logic.
            // This wont' work as we are creating a brand new context.

            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<LiveLogViewerVNC>(context);
                var result = _repository.HasChanges();
                return result;
            }

            Log.DOMAINSERVICES("Exit", Common.LOG_APPNAME, startTicks);

        }

        #endregion Delete

        #endregion

    }
}
